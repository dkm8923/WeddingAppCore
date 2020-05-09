import { Component, OnInit } from '@angular/core';
import { UiAppSettingNavLinkClient } from "../../../../model/dto/wedding-api-models";
import { ActivatedRoute } from '@angular/router';
import { NavLinkService } from '../nav-link.service';
import { ErrorLogService, UtilityService } from '../../../../core';

@Component({
  selector: 'app-nav-link-delete',
  templateUrl: './nav-link-delete.component.html',
  styleUrls: ['./nav-link-delete.component.css']
})
export class NavLinkDeleteComponent implements OnInit {

  id: number;
  data: {};

  constructor(
    private route: ActivatedRoute,
    private client: UiAppSettingNavLinkClient,
    private utilSvc: UtilityService,
    private navLinkSvc: NavLinkService,
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
      this.navLinkSvc.returnToReport();
    }, error => {
      this.errorLogSvc.logError(error);
    });
  }
}
