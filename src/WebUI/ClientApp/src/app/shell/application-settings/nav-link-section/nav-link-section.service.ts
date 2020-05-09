import { Injectable } from '@angular/core';
import { UtilityService } from '../../../core/utility.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})

export class NavLinkSectionService {

  constructor(
    private utilSvc: UtilityService,
    private router: Router
  ) { }

  returnToReport(): void {
    this.utilSvc.hideLoadingSpinner();
    this.router.navigateByUrl('/nav-link-section/nav-link-section')
  }
}
