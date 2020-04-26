import { Component } from '@angular/core';
import { UiAppSettingApplicationClient } from "../../../../model/dto/wedding-api-models";
import { ActivatedRoute } from '@angular/router';
import { ApplicationService } from '../application.service';
import { ErrorLogService, UtilityService } from '../../../../core';

@Component({
  selector: 'app-application-delete',
  templateUrl: './application-delete.component.html',
  styleUrls: ['./application-delete.component.css']
})
export class ApplicationDeleteComponent {
  id: number;
  data: {};

  constructor(
    private route: ActivatedRoute,
    private client: UiAppSettingApplicationClient,
    private utilSvc: UtilityService,
    private applicationSvc: ApplicationService,
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
      this.applicationSvc.returnToReport();
    }, error => {
      this.errorLogSvc.logError(error);
    });
  }
}
