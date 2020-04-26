import { Component } from '@angular/core';
import { UiAppSettingClient } from "../../../../model/dto/wedding-api-models";
import { ActivatedRoute } from '@angular/router';
import { AppSettingsService } from '../app-settings.service';
import { ErrorLogService, UtilityService } from '../../../../core';

@Component({
  selector: 'app-app-settings-delete',
  templateUrl: './app-settings-delete.component.html',
  styleUrls: ['./app-settings-delete.component.css']
})
export class AppSettingsDeleteComponent {
  id: number;
  data: {};

  constructor(
    private route: ActivatedRoute,
    private client: UiAppSettingClient,
    private utilSvc: UtilityService,
    private appSettingsSvc: AppSettingsService,
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
      this.appSettingsSvc.returnToReport();
    }, error => {
      this.errorLogSvc.logError(error);
    });
  }
}
