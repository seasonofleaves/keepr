import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepsService{
  async createVaultKeep(vaultKeepData) {
    const response = await api.post('api/vaultkeeps', vaultKeepData)
    logger.log("created Vaultkeep -vaultkeeps service", response.data)
  }

}

export const vaultKeepsService = new VaultKeepsService()