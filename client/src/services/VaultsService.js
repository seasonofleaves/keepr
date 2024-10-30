import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Vault } from "@/models/Vault.js"
import { AppState } from "@/AppState.js"
import Pop from "@/utils/Pop.js"

class VaultsService{
  async getMyVaults() {
    const response = await api.get('account/vaults')
    logger.log('My vaults????', response.data)
    AppState.myVaults = response.data.map(vaultData => new Vault(vaultData))
  }

  async deleteVault(vaultId, vaultName) {
    const response = await api.delete(`api/vaults/${vaultId}`)
    logger.log('Deleting vault', response.data)
    const vaultIndex = AppState.vaults.findIndex(vault => vault.id == vaultId)
    AppState.vaults.splice(vaultIndex, 1)
    Pop.success(`You deleted vault ${vaultName}`)
  }

  async getVaultById(vaultId) {
    AppState.activeVault = null
    const response = await api.get(`api/vaults/${vaultId}`)
    logger.log('Got vault - vaults service', response.data)
    const newvault = new Vault(response.data)
    AppState.activeVault = newvault
  }

  async getVaultsByProfileId(profileId) {
    const response = await api.get(`api/profiles/${profileId}/vaults`)
    logger.log('Got vaults for profile - vaults service', response.data)
    const newVaults = response.data.map(vaultData => new Vault(vaultData))
    AppState.vaults = newVaults
  }

  async createVault(vaultData) {
    const response = await api.post('api/vaults', vaultData)
    logger.log('Created vault', response.data)
    const newVault = new Vault(response.data)
    AppState.vaults.push(newVault)
    Pop.success(`You created a new vault!`)
    AppState.myVaults.push(newVault)
  }

}

export const vaultsService = new VaultsService()