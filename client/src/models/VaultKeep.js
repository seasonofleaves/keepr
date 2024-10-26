import { DBItem } from "./DBItem.js";
import { Keep } from "./Keep.js";
import { Profile } from "./Profile.js";
import { Vault } from "./Vault.js";

export class VaultKeep extends DBItem{
  constructor(data){
    super(data)
    this.keepId = data.keepId
    this.vaultId = data.vaultId
  }
}

export class KeepVaultKeep extends Keep{
  constructor(data){
    super(data)
    this.vaultKeepId = data.vaultKeepId
    this.vaultId = data.vaultId
  }
}

export class VaultKeepProfile extends VaultKeep{
  constructor(data){
    super(data)
    this.profile = new Profile(data.profile)
  }
}

export class VaultKeepInVault extends VaultKeep{
  constructor(data){
    super(data)
    this.vault = new Vault(data.vault)
  }
}