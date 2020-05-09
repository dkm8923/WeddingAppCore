import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { UiAppSettingNavLinkClient, CreateUiAppSettingNavLinkCommand, UpdateUiAppSettingNavLinkCommand } from "../../../../model/dto/wedding-api-models";
import { ErrorLogService, UtilityService } from '../../../../core';
import { FormValidationService } from '../../../../shared';
import { NavLinkService } from '../nav-link.service';

@Component({
  selector: 'app-nav-link-create-edit',
  templateUrl: './nav-link-create-edit.component.html',
  styleUrls: ['./nav-link-create-edit.component.css']
})
export class NavLinkCreateEditComponent implements OnInit {

  formGroup: FormGroup;
  id: number;
  private formSubmitAttempt: boolean;

  constructor(
    private route: ActivatedRoute,
    private client: UiAppSettingNavLinkClient,
    private utilSvc: UtilityService,
    private formValSvc: FormValidationService,
    private errorLogSvc: ErrorLogService,
    private formBuilder: FormBuilder,
    private navLinkSvc: NavLinkService,
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
          applicationId: result[0].applicationId,
          navLinkSectionId: result[0].navLinkSectionId,
          text: result[0].text,
          fontAwesomeCss: result[0].fontAwesomeCss,
          url: result[0].url,
          badgeText: result[0].badgeText
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
    this.client.create(<CreateUiAppSettingNavLinkCommand>{
      applicationId: this.formGroup.value.applicationId,
      navLinkSectionId: this.formGroup.value.navLinkSectionId,
      text: this.formGroup.value.text,
      fontAwesomeCss: this.formGroup.value.fontAwesomeCss,
      url: this.formGroup.value.url,
      badgeText: this.formGroup.value.badgeText
    }).subscribe(
      result => {
        console.log("Post Result");
        console.log(result);
        this.navLinkSvc.returnToReport();
      },
      error => {
        this.errorLogSvc.logError(error);
      }
    );
  }

  edit() {
    this.client.update(this.id, <UpdateUiAppSettingNavLinkCommand>{
      id: this.id,
      applicationId: this.formGroup.value.applicationId,
      navLinkSectionId: this.formGroup.value.navLinkSectionId,
      text: this.formGroup.value.text,
      fontAwesomeCss: this.formGroup.value.fontAwesomeCss,
      url: this.formGroup.value.url,
      badgeText: this.formGroup.value.badgeText
    }).subscribe(
      result => {
        console.log("Post Result");
        console.log(result);
        this.navLinkSvc.returnToReport();
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
