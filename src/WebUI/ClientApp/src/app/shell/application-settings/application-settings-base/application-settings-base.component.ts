import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

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
    //private client: UsaStateClient,
    private utilSvc: UtilityService,
    private formValSvc: FormValidationService,
    private errorLogSvc: ErrorLogService,
    private formBuilder: FormBuilder,
    //private usaStateSvc: UsaStateService,
  ) {

    this.formGroup = this.formBuilder.group({
      name: ['', Validators.required],
      abbreviatedName: ['', Validators.required]
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

  onSubmit(): void {
    this.formSubmitAttempt = true;

    console.log("Submit Data");

    //if (this.formGroup.valid) {

    //  this.utilSvc.showLoadingSpinner();

    //  //data is being edited
    //  if (this.id) {
    //    this.edit();
    //  }
    //  else {
    //    //create new record
    //    this.create();
    //  }
    //}
  }

}
