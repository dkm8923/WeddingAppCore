import { Component, OnInit } from '@angular/core';
import { UiAppSettingNavLinkSectionClient } from "../../../../model/dto/wedding-api-models";
import { ActivatedRoute } from '@angular/router';
import { NavLinkSectionService } from '../nav-link-section.service';
import { ErrorLogService, UtilityService } from '../../../../core';

@Component({
  selector: 'app-nav-link-section-delete',
  templateUrl: './nav-link-section-delete.component.html',
  styleUrls: ['./nav-link-section-delete.component.css']
})
export class NavLinkSectionDeleteComponent implements OnInit {

  id: number;
  data: {};

  constructor(
    private route: ActivatedRoute,
    private client: UiAppSettingNavLinkSectionClient,
    private utilSvc: UtilityService,
    private navLinkSectionSvc: NavLinkSectionService,
    private errorLogSvc: ErrorLogService
  ) {

  }

  ngOnInit(): void {
    this.id = parseInt(this.route.snapshot.paramMap.get('id'));

    //load data for id and set form in edit mode
    if (this.id) {
      this.utilSvc.showLoadingSpinner();

      this.client.get(this.id).subscribe(result => {
        this.data = result[0];
        this.utilSvc.hideLoadingSpinner();
      },
        error => {
          this.errorLogSvc.logError(error);
        });
    }
  }

  onSubmit() {
    this.utilSvc.showLoadingSpinner();

    this.client.delete(this.id).subscribe(result => {
      this.navLinkSectionSvc.returnToReport();
    }, error => {
      this.errorLogSvc.logError(error);
    });
  }
}
