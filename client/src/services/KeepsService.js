import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"
import Pop from "@/utils/Pop.js"
import { VaultKeep } from "@/models/VaultKeep.js"

class KeepsService{
  async getKeepsInVault(vaultId) {
    const response = await api.get(`api/vaults/${vaultId}/keeps`)
    // logger.log('Got keeps in vault - keeps service', response.data)
    const newVaultKeep = response.data.map(vaultKeepData => new VaultKeep(vaultKeepData))
    AppState.vaultKeeps = newVaultKeep
  }

  async getKeepsByProfileId(profileId) {
    const response = await api.get(`api/profiles/${profileId}/keeps`)
    // logger.log('Got keeps for profile - keeps service', response.data)
    const newKeeps = response.data.map(keepData => new Keep(keepData))
    AppState.keeps = newKeeps
  }

  async getKeepById(keepId) {
    const response = await api.get(`api/keeps/${keepId}`)
    // logger.log('Got keep by id', response.data)
    const activeKeep = new Keep(response.data)
    AppState.activeKeep = activeKeep
  }

  async deleteKeep(keepId, keepName) {
    const response = await api.delete(`api/keeps/${keepId}`)
    logger.log('Deleting keep', response.data)
    const keepIndex = AppState.keeps.findIndex(keep => keep.id == keepId)
    AppState.keeps.splice(keepIndex, 1)
    Pop.success(`You deleted keep ${keepName}`)
  }

  async createKeep(keepData) {
    const response = await api.post('api/keeps', keepData)
    // logger.log('Created keep', response.data)
    const newKeep = new Keep(response.data)
    if(AppState.activeProfile?.id == newKeep.creatorId) AppState.keeps.push(newKeep)
    if(AppState.activeProfile == null) AppState.keeps.push(newKeep)
    Pop.success(`You created a keep!`)
  }

  setActiveKeep(keep) {
    AppState.activeKeep = null
    AppState.activeKeep = keep
  }

  async getAllKeeps() {
    const response = await api.get('api/keeps')
    // logger.log('Got all keeps - keeps service', response.data)
    const newKeeps = response.data.map(keepData => new Keep(keepData))
    AppState.keeps = newKeeps
  }
}

export const keepsService = new KeepsService()