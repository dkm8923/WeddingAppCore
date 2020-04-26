import { Injectable } from '@angular/core';
import { UtilityService } from '../../../core/utility.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})

export class ApplicationService {

  constructor(
    private utilSvc: UtilityService,
    private router: Router
  ) { }

  returnToReport(): void {
    this.utilSvc.hideLoadingSpinner();
    this.router.navigateByUrl('/application-settings/application')
  }
}
