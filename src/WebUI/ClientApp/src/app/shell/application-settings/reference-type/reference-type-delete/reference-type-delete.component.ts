import { Component } from '@angular/core';
import { UiAppSettingReferenceTypeClient } from "../../../../model/dto/wedding-api-models";
import { ActivatedRoute } from '@angular/router';
import { ReferenceTypeService } from '../reference-type.service';
import { ErrorLogService, UtilityService } from '../../../../core';

@Component({
  selector: 'app-reference-type-delete',
  templateUrl: './reference-type-delete.component.html',
  styleUrls: ['./reference-type-delete.component.css']
})
export class ReferenceTypeDeleteComponent {
  id: number;
  data: {};

  constructor(
    private route: ActivatedRoute,
    private client: UiAppSettingReferenceTypeClient,
    private utilSvc: UtilityService,
    private referenceTypeSvc: ReferenceTypeService,
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
      this.referenceTypeSvc.returnToReport();
    }, error => {
      this.errorLogSvc.logError(error);
    });
  }
}
