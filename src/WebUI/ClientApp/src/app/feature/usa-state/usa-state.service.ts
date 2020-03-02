import { Injectable } from '@angular/core';
import { UtilityService } from '../../core/utility.service';

@Injectable({
  providedIn: 'root',
})

export class UsaStateService {

  constructor(
    private utilSvc: UtilityService,
  ) { }

  returnToReport(): void {
    this.utilSvc.hideLoadingSpinner();
    this.utilSvc.navigateRouter('usa-state');
  }
}
