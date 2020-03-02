import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { UsaStateClient, CreateUsaStateCommand, UpdateUsaStateCommand } from "../../../cleanarchitecture-api";
import { UtilityService } from '../../../core/utility.service';
import { FormValidationService } from '../../../shared/form-elements/validation/form-validation.service';
import { ErrorLogService } from '../../../core/error-log.service';
import { UsaStateService } from '../usa-state.service';

@Component({
  selector: 'app-usa-state-detail',
  templateUrl: './usa-state-create-edit.component.html',
  styleUrls: ['./usa-state-create-edit.component.css']
})
export class UsaStateCreateEditComponent implements OnInit {

  formGroup: FormGroup;
  id: number;
  private formSubmitAttempt: boolean;

  constructor(
    private route: ActivatedRoute,
    private client: UsaStateClient,
    private utilSvc: UtilityService,
    private formValSvc: FormValidationService,
    private errorLogSvc: ErrorLogService,
    private formBuilder: FormBuilder,
    private usaStateSvc: UsaStateService,
  ) {
    
    this.formGroup = this.formBuilder.group({
      name: ['', Validators.required],
      abbreviatedName: ['', Validators.required]
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
          abbreviatedName: result[0].abbreviatedName
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
    this.client.create(<CreateUsaStateCommand>{
      name: this.formGroup.value.name,
      abbreviatedName: this.formGroup.value.abbreviatedName
    }).subscribe(
      result => {
        console.log("Post Result");
        console.log(result);
        this.usaStateSvc.returnToReport();
      },
      error => {
        this.errorLogSvc.logError(error);
      }
    );
  }

  edit() {
    this.client.update(this.id, <UpdateUsaStateCommand>{
      id: this.id,
      name: this.formGroup.value.name,
      abbreviatedName: this.formGroup.value.abbreviatedName
    }).subscribe(
      result => {
        console.log("Post Result");
        console.log(result);
        this.usaStateSvc.returnToReport();
      },
      error => {
        this.errorLogSvc.logError(error);
      }
    );
  }

  onSubmit(): void
  {
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
