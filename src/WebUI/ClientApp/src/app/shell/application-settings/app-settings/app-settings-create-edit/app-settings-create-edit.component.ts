import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { UiAppSettingClient, CreateUiAppSettingCommand, UpdateUiAppSettingCommand } from "../../../../model/dto/wedding-api-models";
import { ErrorLogService, UtilityService } from '../../../../core';
import { FormValidationService } from '../../../../shared';
import { AppSettingsService } from '../app-settings.service';

@Component({
  selector: 'app-app-settings-create-edit',
  templateUrl: './app-settings-create-edit.component.html',
  styleUrls: ['./app-settings-create-edit.component.css']
})
export class AppSettingsCreateEditComponent implements OnInit {

  formGroup: FormGroup;
  id: number;
  private formSubmitAttempt: boolean;

  constructor(
    private route: ActivatedRoute,
    private client: UiAppSettingClient,
    private utilSvc: UtilityService,
    private formValSvc: FormValidationService,
    private errorLogSvc: ErrorLogService,
    private formBuilder: FormBuilder,
    private appSettingsSvc: AppSettingsService,
  ) {

    this.formGroup = this.formBuilder.group({
      applicationId: new FormControl(''),
      referenceTypeId: new FormControl(''),
      footer: new FormGroup({
        textLeft: new FormControl(''),
        textMiddle: new FormControl(''),
        textRight: new FormControl(''),
      })
    });
  }

  ngOnInit(): void {
    this.id = parseInt(this.route.snapshot.paramMap.get('id'));

    //load data for id and set form in edit mode
    if (this.id) {
      this.utilSvc.showLoadingSpinner();

      this.client.get(this.id).subscribe(result => {

        //parse json
        result[0].json = JSON.parse(result[0].json);

        console.log("App Settings Edit");
        console.log(result);

        this.formGroup.setValue({
          applicationId: result[0].applicationId,
          referenceTypeId: result[0].referenceTypeId,
          //footer: {
          //  textLeft: result[0].footer.textLeft,
          //  textMiddle: "",
          //  textRight: ""
          //}
          footer: {
            textLeft: result[0].json.textLeft,
            textMiddle: result[0].json.textMiddle,
            textRight: result[0].json.textRight
          }
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
    this.client.create(<CreateUiAppSettingCommand>{
      applicationId: 1,
      referenceTypeId: 2,
      json: JSON.stringify(this.formGroup.value.footer)
    }).subscribe(
      result => {
        console.log("Post Result");
        console.log(result);
        this.appSettingsSvc.returnToReport();
      },
      error => {
        this.errorLogSvc.logError(error);
      }
    );
  }

  edit() {
    this.client.update(this.id, <UpdateUiAppSettingCommand>{
      id: this.id,
      applicationId: 1,
      referenceTypeId: 2,
      json: JSON.stringify(this.formGroup.value.footer)
    }).subscribe(
      result => {
        console.log("Post Result");
        console.log(result);
        this.appSettingsSvc.returnToReport();
      },
      error => {
        this.errorLogSvc.logError(error);
      }
    );
  }

  onSubmit(): void {
    this.formSubmitAttempt = true;

    console.log("Submit Data");
    //console.log(this.formGroup.value);
    //console.log(this.formGroup.value.footer.textMiddle); 
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
