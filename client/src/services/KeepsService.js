import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class KeepsService{
  async getAllKeeps() {
    const response = await api.get('api/keeps')
    logger.log('Got all keeps - keeps service', response.data)
  }

}

export const keepsService = new KeepsService()