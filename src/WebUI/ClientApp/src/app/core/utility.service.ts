import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})

export class UtilityService {

  constructor(
    private router: Router
  ) {}

  showLoadingSpinner() {
    //add class to the application base body element
    document.getElementById("appBodyBase").classList.add("appLoading");
    //show global loading spinner 
    document.getElementById("loadingSpinner").classList.remove("hidden");
  }

  hideLoadingSpinner() {
    //remove class from the application base body element
    document.getElementById("appBodyBase").classList.remove("appLoading");
    //hide global loading spinner 
    document.getElementById("loadingSpinner").classList.add("hidden");
  }

  navigateRouter(url: string) {
    this.router.navigate(['/', url]).then(
      err => {
        console.log(err) // when there's an error
      });
  }
}
