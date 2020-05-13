import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { UiAppSettingNavLinkSectionClient, CreateUiAppSettingNavLinkSectionCommand, UpdateUiAppSettingNavLinkSectionCommand } from "../../../../model/dto/wedding-api-models";
import { ErrorLogService, UtilityService } from '../../../../core';
import { FormValidationService } from '../../../../shared';
import { NavLinkSectionService } from '../nav-link-section.service';


@Component({
  selector: 'app-nav-link-section-create-edit',
  templateUrl: './nav-link-section-create-edit.component.html',
  styleUrls: ['./nav-link-section-create-edit.component.css']
})
export class NavLinkSectionCreateEditComponent implements OnInit {

  formGroup: FormGroup;
  id: number;
  private formSubmitAttempt: boolean;

  constructor(
    private route: ActivatedRoute,
    private client: UiAppSettingNavLinkSectionClient,
    private utilSvc: UtilityService,
    private formValSvc: FormValidationService,
    private errorLogSvc: ErrorLogService,
    private formBuilder: FormBuilder,
    private navLinkSectionService: NavLinkSectionService,
  ) {

    this.formGroup = this.formBuilder.group({
      applicationId: ['', Validators.required],
      text: ['', Validators.required],
      fontAwesomeCss: [''],
      badgeText: ['']
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
          text: result[0].text,
          fontAwesomeCss: result[0].fontAwesomeCss,
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
    this.client.create(<CreateUiAppSettingNavLinkSectionCommand>{
      applicationId: this.formGroup.value.applicationId,
      text: this.formGroup.value.text,
      fontAwesomeCss: this.formGroup.value.fontAwesomeCss,
      badgeText: this.formGroup.value.badgeText
    }).subscribe(
      result => {
        console.log("Post Result");
        console.log(result);
        this.navLinkSectionService.returnToReport();
      },
      error => {
        this.errorLogSvc.logError(error);
      }
    );
  }

  edit() {
    this.client.update(this.id, <UpdateUiAppSettingNavLinkSectionCommand>{
      id: this.id,
      applicationId: this.formGroup.value.applicationId,
      text: this.formGroup.value.text,
      fontAwesomeCss: this.formGroup.value.fontAwesomeCss,
      badgeText: this.formGroup.value.badgeText
    }).subscribe(
      result => {
        console.log("Post Result");
        console.log(result);
        this.navLinkSectionService.returnToReport();
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
