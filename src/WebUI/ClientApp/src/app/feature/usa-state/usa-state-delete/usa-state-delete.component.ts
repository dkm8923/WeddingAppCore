import { Component } from '@angular/core';
import { UsaStateClient } from "../../../model/dto/wedding-api-models";
import { ActivatedRoute } from '@angular/router';
import { UsaStateService } from '../../usa-state';
import { ErrorLogService, UtilityService } from '../../../core';

@Component({
  selector: 'app-usa-state-delete',
  templateUrl: './usa-state-delete.component.html',
  styleUrls: ['./usa-state-delete.component.css']
})
export class UsaStateDeleteComponent {
  id: number;
  state: {};

  constructor(
    private route: ActivatedRoute,
    private client: UsaStateClient,
    private utilSvc: UtilityService,
    private usaStateSvc: UsaStateService,
    private errorLogSvc: ErrorLogService
  ) {

  }

  ngOnInit(): void {
    this.id = parseInt(this.route.snapshot.paramMap.get('id'));

    //load data for id and set form in edit mode
    if (this.id) {
      this.utilSvc.showLoadingSpinner();

      this.client.get(this.id).subscribe(result => {
        this.state = result[0]; 
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
      this.usaStateSvc.returnToReport();
    }, error => {
      this.errorLogSvc.logError(error);
    });
  }
}
