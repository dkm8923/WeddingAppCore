import { Injectable } from '@angular/core';
import { UtilityService } from '../core/utility.service';

@Injectable({
  providedIn: 'root',
})

export class ErrorLogService {

  constructor(private utilSvc: UtilityService) {}

  logError(error) {
    this.utilSvc.hideLoadingSpinner();

    let errors = JSON.parse(error.response);

    if (errors) {
      console.log("Log Error(s):");
      console.log(errors);
    }
  }
}
