import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { VaultKeep } from "@/models/VaultKeep.js"
import { AppState } from "@/AppState.js"

class VaultKeepsService{
  async createVaultKeep(vaultKeepData) {
    const response = await api.post('api/vaultkeeps', vaultKeepData)
    // logger.log("created Vaultkeep -vaultkeeps service", response.data)
    const newVaultKeep = response.data.map(vaultKeepData => new VaultKeep(vaultKeepData))
    AppState.vaultKeeps = newVaultKeep
  }

}

export const vaultKeepsService = new VaultKeepsService()