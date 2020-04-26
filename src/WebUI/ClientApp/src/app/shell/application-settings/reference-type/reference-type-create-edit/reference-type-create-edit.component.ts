import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { UiAppSettingReferenceTypeClient, CreateUiAppSettingReferenceTypeCommand, UpdateUiAppSettingReferenceTypeCommand } from "../../../../model/dto/wedding-api-models";
import { ErrorLogService, UtilityService } from '../../../../core';
import { FormValidationService } from '../../../../shared';
import { ReferenceTypeService } from '../reference-type.service';

@Component({
  selector: 'app-reference-type-create-edit',
  templateUrl: './reference-type-create-edit.component.html',
  styleUrls: ['./reference-type-create-edit.component.css']
})
export class ReferenceTypeCreateEditComponent implements OnInit {

  formGroup: FormGroup;
  id: number;
  private formSubmitAttempt: boolean;

  constructor(
    private route: ActivatedRoute,
    private client: UiAppSettingReferenceTypeClient,
    private utilSvc: UtilityService,
    private formValSvc: FormValidationService,
    private errorLogSvc: ErrorLogService,
    private formBuilder: FormBuilder,
    private referenceTypeSvc: ReferenceTypeService,
  ) {

    this.formGroup = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.id = parseInt(this.route.snapshot.paramMap.get('id'));

    //load data for id and set form in edit mode
    if (this.id) {
      this.utilSvc.showLoadingSpinner();

      this.client.get(this.id).subscribe(result => {
        console.log("Usa State edit");
        console.log(result);

        this.formGroup.setValue({
          name: result[0].name,
          description: result[0].description
        });

        this.utilSvc.hideLoadingSpinner();
      },
        error => {
          this.errorLogSvc.logError(error);
        });
    }

    //set focus to name textbox
    //setTimeout(() => document.getElementById("txtName").focus(), 250);
  }

  displayFieldCss(field: string) {
    return this.formValSvc.displayFieldCss(field, this.formSubmitAttempt, this.formGroup);
  }

  isFieldValid(field: string) {
    return this.formValSvc.isFieldValid(field, this.formSubmitAttempt, this.formGroup);
  }

  create() {
    this.client.create(<CreateUiAppSettingReferenceTypeCommand>{
      name: this.formGroup.value.name,
      description: this.formGroup.value.description
    }).subscribe(
      result => {
        console.log("Post Result");
        console.log(result);
        this.referenceTypeSvc.returnToReport();
      },
      error => {
        this.errorLogSvc.logError(error);
      }
    );
  }

  edit() {
    this.client.update(this.id, <UpdateUiAppSettingReferenceTypeCommand>{
      id: this.id,
      name: this.formGroup.value.name,
      description: this.formGroup.value.description
    }).subscribe(
      result => {
        console.log("Post Result");
        console.log(result);
        this.referenceTypeSvc.returnToReport();
      },
      error => {
        this.errorLogSvc.logError(error);
      }
    );
  }

  onSubmit(): void {
    this.formSubmitAttempt = true;

    if (this.formGroup.valid) {

      this.utilSvc.showLoadingSpinner();

      //data is being edited
      if (this.id) {
        this.edit();
      }
      else {
        //create new record
        this.create();
      }
    }
  }
}
