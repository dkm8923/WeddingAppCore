//import { Component } from '@angular/core';
//import { WeddingDescriptionClient, WeddingDescriptionDto, GetWeddingDescriptionQuery } from "../../cleanarchitecture-api";
//import { faSave, faTimes , faTrash, faPencilAlt, faPlus} from '@fortawesome/free-solid-svg-icons';
//@Component({
//  selector: 'wedding-description',
//  templateUrl: './wedding-description.component.html',
//  styleUrls: ['./wedding-description.component.css']
//})
//export class WeddingDescriptionComponent {
//  public descData: WeddingDescriptionDto[];
//  faSave = faSave;
//  faTimes = faTimes;
//  faTrash = faTrash;
//  faPencil = faPencilAlt;
//  faPlus = faPlus;
//  constructor(private client: WeddingDescriptionClient) {
//    let req = new GetWeddingDescriptionQuery();
//    req.id = 1;
//    req.groomDescription = "test";
//    client.get().subscribe(result => {
//      this.descData = result;
//      console.log("Wedding Description Data!!!");
//      console.log(this.descData);
//    }, error => console.error(error));
//  }
//  closeCreateEditWindow(): void {
//    console.log("close window / cancel");
//  }
//  createNewRecord(): void {
//    console.log("create new record");
//  }
//  save(): void {
//    console.log("save data");
//  }
//  edit(req: WeddingDescriptionDto): void {
//    console.log("edit data");
//    console.log(req);
//  }
//  delete(req: WeddingDescriptionDto): void {
//    console.log("delete data");
//    console.log(req);
//  }
//}
//# sourceMappingURL=wedding-description.component.js.map