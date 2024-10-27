import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Vault } from "@/models/Vault.js"
import { AppState } from "@/AppState.js"

class VaultsService{
  async createVault(vaultData) {
    const response = await api.post('api/vaults', vaultData)
    logger.log('Created vault', response.data)
    const newVault = new Vault(response.data)
    AppState.vaults.push(newVault)
  }

}

export const vaultsService = new VaultsService()