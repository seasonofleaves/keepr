<script setup>
import { vaultsService } from '@/services/VaultsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()

onMounted(() =>{
  getVaultById()
})

async function getVaultById(){
  try {
    const vaultId = route.params.vaultId
    logger.log('Id of the vault from the URL', vaultId)
    await vaultsService.getVaultById(vaultId)
  }
  catch (error){
    Pop.error(error)
    logger.log(error)
  }
}

</script>


<template>
<h1>Vault Page</h1>
</template>


<style lang="scss" scoped>

</style>