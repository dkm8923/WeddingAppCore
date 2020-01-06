import { Component } from '@angular/core';
import { WeddingDescriptionDto } from "../../cleanarchitecture-api";
import { faSave, faTimes, faTrash, faPencilAlt, faPlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'wedding-description-create-edit',
  templateUrl: './wedding-description-create-edit.component.html',
  styleUrls: ['./wedding-description-create-edit.component.css']
})
export class WeddingDescriptionCreateEditComponent {

  public descData: WeddingDescriptionDto[];

  faSave = faSave;
  faTimes = faTimes;
  faTrash = faTrash;
  faPencil = faPencilAlt;
  faPlus = faPlus;

  //constructor(private client: WeddingDescriptionClient) {
  //  let req = new GetWeddingDescriptionQuery();
  //  req.id = 1;
  //  req.groomDescription = "test";
  //  client.get(req).subscribe(result => {
  //    this.descData = result;
  //    console.log("Wedding Description Data!!!");
  //    console.log(this.descData);
  //  }, error => console.error(error));
  //}

  constructor() {
    console.log("Create Edit Component loaded");
  }

  //closeCreateEditWindow(): void {
  //  console.log("close window / cancel");
  //}

  //createNewRecord(): void {
  //  console.log("create new record");
  //}

  //save(): void {
  //  console.log("save data");
  //}

  //edit(req: WeddingDescriptionDto): void {
  //  console.log("edit data");
  //  console.log(req);
  //}

  //delete(req: WeddingDescriptionDto): void {
  //  console.log("delete data");
  //  console.log(req);
  //}
}
