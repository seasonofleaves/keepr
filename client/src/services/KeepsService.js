import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"

class KeepsService{
  async createKeep(keepData) {
    const response = await api.post('api/keeps', keepData)
    logger.log('Created keep', response.data)
    const newKeep = new Keep(response.data)
    AppState.keeps.push(newKeep)
  }
  setActiveKeep(keep) {
    AppState.activeKeep = null
    AppState.activeKeep = keep
  }
  async getAllKeeps() {
    const response = await api.get('api/keeps')
    logger.log('Got all keeps - keeps service', response.data)
    const newKeeps = response.data.map(keepData => new Keep(keepData))
    AppState.keeps = newKeeps
  }
}

export const keepsService = new KeepsService()