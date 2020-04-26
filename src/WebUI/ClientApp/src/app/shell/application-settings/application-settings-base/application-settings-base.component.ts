import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { UiAppSettingClient, CreateUiAppSettingCommand, UpdateUiAppSettingCommand } from "../../../model/dto/wedding-api-models";
import { ErrorLogService, UtilityService } from '../../../core';
import { FormValidationService } from '../../../shared';

@Component({
  selector: 'app-application-settings-base',
  templateUrl: './application-settings-base.component.html',
  styleUrls: ['./application-settings-base.component.css']
})
export class ApplicationSettingsBaseComponent implements OnInit {

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
    private router: Router
    //private usaStateSvc: UsaStateService,
  ) {

    this.formGroup = this.formBuilder.group({
      applicationId: new FormControl(''),
      referenceTypeId: new FormControl(''),
      footer: new FormGroup({
        textLeft: new FormControl('text left'),
        textMiddle: new FormControl('text middle'),
        textRight: new FormControl('text right'),
      })
    });
  }

  ngOnInit(): void {
    //this.id = parseInt(this.route.snapshot.paramMap.get('id'));

    this.utilSvc.showLoadingSpinner();

    //load data for id and set form in edit mode
    //if (this.id) {
    //  this.utilSvc.showLoadingSpinner();

    //  this.client.get(this.id).subscribe(result => {
    //    console.log("Usa State edit");
    //    console.log(result);

    //    this.formGroup.setValue({
    //      name: result[0].name,
    //      abbreviatedName: result[0].abbreviatedName
    //    });

    //    this.utilSvc.hideLoadingSpinner();
    //  },
    //    error => {
    //      this.errorLogSvc.logError(error);
    //    });
    //}

    //set focus to name textbox
    //setTimeout(() => document.getElementById("txtName").focus(), 250);

    this.utilSvc.hideLoadingSpinner();
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
        this.returnToReport();
      },
      error => {
        this.errorLogSvc.logError(error);
      }
    );
  }

  edit() {
    this.client.update(this.id, <UpdateUiAppSettingCommand>{
      applicationId: 1,
      referenceTypeId: 2,
      json: JSON.stringify(this.formGroup.value.footer)
    }).subscribe(
      result => {
        console.log("Post Result");
        console.log(result);
        this.returnToReport();
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

  returnToReport() {
    this.utilSvc.hideLoadingSpinner();
    this.router.navigateByUrl('/application-settings')
  }

}
