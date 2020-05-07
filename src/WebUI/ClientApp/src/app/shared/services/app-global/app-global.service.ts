import { Injectable } from '@angular/core';

import { CommonClient, GetCommonDataRequest, GetCommonDataResponse } from "../../../model/dto/wedding-api-models";

@Injectable()
export class AppGlobalService {

  private commonData: GetCommonDataResponse = null;

  constructor(private client: CommonClient) {}

  getCommonData() {
    return this.commonData;
  }

  loadInitData() {

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

