import { Injectable } from '@angular/core';

import { AuthorizeService } from '../../../../api-authorization/authorize.service';

import { CommonClient, GetCommonDataRequest, GetCommonDataResponse } from "../../../model/dto/wedding-api-models";

@Injectable()
export class AppGlobalService {

  public isAuthenticated;
  public userInfo;
  private commonData: GetCommonDataResponse = null;

  constructor(
    private authorizeSvc: AuthorizeService,
    private client: CommonClient
  ) {

    this.isAuthenticated = authorizeSvc.isAuthenticated().subscribe(data => {
      console.log("isAuthenticated");
      console.log(data); 
    });

    this.userInfo = authorizeSvc.getUser().subscribe(data => {
      console.log("User");
      console.log(data);
    });
  }

  //isUserAuthenticated() {
  //  return this.isAuthenticated;
  //}

  getCommonData() {
    return this.commonData;
  }

  //getUserInfo() {
  //  return this.userInfo;
  //}

  loadInitData() {
    if (this.isAuthenticated) {
      var commonDataReq = {
        usaStates: true,
        uiAppSettingReferenceTypes: true,
        uiAppSettingApplications: true,
        uiAppSettings: true
      };

      //return new Promise((resolve, reject) => {
      //  this.client.getCommonData(new GetCommonDataRequest(commonDataReq)).subscribe(result => {
      //    this.commonData = result;
      //    console.log("Global Common Data:");
      //    console.log(this.commonData);
      //    resolve(true);
      //  }, error => console.error(error))
      //});
    }
  }
}

