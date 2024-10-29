<script setup>
import { AppState } from '@/AppState.js';
import { vaultsService } from '@/services/VaultsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()
const activeVault = computed(() => AppState.activeVault)

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
<!-- NOTE HEADER -->
<div v-if="activeVault" class="container">
  <br>
  <section class="row justify-content-center">
    <div class="col-6 d-flex flex-column cover-img-bg justify-content-end shadow" :style="{backgroundImage:`url(${activeVault.img})`}">
      <div class="cover-img-text">
        <div class="d-flex justify-content-center">
          <h1 class="fw-bold text-uppercase text-light">{{ activeVault.name }}</h1>
        </div>
        <div class="d-flex justify-content-center mb-5">
          <h5 class="fw-bold text-light">by {{ activeVault.creator.name }}</h5>
        </div>
      </div>
    </div>
  </section>
</div>
</template>


<style lang="scss" scoped>
.cover-img-bg{
  height: 40dvh;
  background-size: cover;
  background-position: center;
  border-radius: 5px;
}

.cover-img-text{
  text-shadow: 1px 1px 10px rgb(0, 0, 0);
}
</style>