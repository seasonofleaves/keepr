import { DBItem } from "./DBItem.js";
import { Profile } from "./Profile.js";

export class Vault extends DBItem{
  constructor(data){
    super(data)
    this.name = data.name
    this.description = data.description
    this.img = data.img
    this.isPrivate = data.isPrivate
    this.creatorId = data.creatorId
    this.creator = data.creator ? new Profile(data.creator) : null
  }
}