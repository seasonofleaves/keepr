import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { VaultKeep } from "@/models/VaultKeep.js"
import { AppState } from "@/AppState.js"
import Pop from "@/utils/Pop.js"

class VaultKeepsService{
  async deleteKeepInVault(vaultKeepId) {
    const response = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
    logger.log("Deleting vaultkeep - vaultkeeps service", response.data)
  }

  async createVaultKeep(vaultKeepData) {
    const response = await api.post('api/vaultkeeps', vaultKeepData)
    logger.log("created Vaultkeep -vaultkeeps service", response.data)
    Pop.success(`You added keep to vault!`)
  }
}

export const vaultKeepsService = new VaultKeepsService()