import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Vault } from "@/models/Vault.js"
import { AppState } from "@/AppState.js"
import Pop from "@/utils/Pop.js"

class VaultsService{
  async getVaultsByProfileId(profileId) {
    const response = await api.get(`api/profiles/${profileId}/vaults`)
    logger.log('Got vaults for profile - vaults service', response.data)

  }

  async createVault(vaultData) {
    const response = await api.post('api/vaults', vaultData)
    logger.log('Created vault', response.data)
    const newVault = new Vault(response.data)
    AppState.vaults.push(newVault)
    Pop.success(`You created a new vault!`)
  }

}

export const vaultsService = new VaultsService()