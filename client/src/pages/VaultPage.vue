<script setup>
import { AppState } from '@/AppState.js';
import KeepCard from '@/components/KeepCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import { vaultKeepsService } from '@/services/VaultKeepsService.js';
import { vaultsService } from '@/services/VaultsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';

const route = useRoute()
const router = useRouter()
const account = computed(() => AppState.account)
const activeVault = computed(() => AppState.activeVault)
const vaultKeeps = computed(() => AppState.vaultKeeps)

onMounted(() => {
  getVaultById()
  getKeepsInVault()
})

async function getVaultById() {
  try {
    const vaultId = route.params.vaultId
    logger.log('Id of the vault from the URL', vaultId)
    await vaultsService.getVaultById(vaultId)
  }
  catch (error) {
    Pop.error(error)
    logger.log(error)
    if (error.response.data == "Not your vault!") {
      router.push({ name: 'Home' })
    }
  }
}

async function getKeepsInVault() {
  try {
    const vaultId = route.params.vaultId
    await keepsService.getKeepsInVault(vaultId)
  }
  catch (error) {
    Pop.error(error)
    logger.log
  }
}

async function deleteKeepInVault(vaultKeepId) {
  try {
    const wantsToDelete = await Pop.confirm(`Are you sure you want to delete this keep?`)
    if (!wantsToDelete) return
    await vaultKeepsService.deleteKeepInVault(vaultKeepId)
  }
  catch (error) {
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
      <div :title="`Cover image for vault ${activeVault.name}`"
        class="col-11 col-lg-6 d-flex flex-column cover-img-bg justify-content-end shadow"
        :style="{ backgroundImage: `url(${activeVault.img})` }">
        <div class="cover-img-text">
          <div class="d-flex justify-content-center">
            <h1 :title="activeVault.name" class="fw-bold text-uppercase text-light">{{ activeVault.name }}</h1>
          </div>
          <div class="d-flex justify-content-center mb-5">
            <h5 :title="`By ${activeVault.creator.name}`" class="fw-bold text-light">by {{ activeVault.creator.name }}
            </h5>
          </div>
        </div>
      </div>
      <div class="col-12 d-flex justify-content-center">
        <div :title="`${vaultKeeps.length} keeps in vault`" class="d-flex flex-column text-center mt-2">
          <p class="btn btn-primary">{{ vaultKeeps.length }} Keeps</p>
        </div>
      </div>
    </section>
  </div>

  <!-- NOTE VAULT KEEPS -->
  <div class="container">
    <section class="row">
      <div class="d-flex justify-content-center">
        <div class="col-12 col-md-10 mb-3">
          <h4 title="Keeps in vault" class="mb-3">Keeps</h4>
          <div class="masonry-layout">
            <div class="masonry-item" v-for="vaultKeep in vaultKeeps" :key="vaultKeep.id">
              <div class="d-flex justify-content-end">
                <KeepCard :keep="vaultKeep" />
                <i v-if="vaultKeep.accountId == account?.id" @click.stop="deleteKeepInVault(vaultKeep.vaultKeepId)"
                  :title="`Remove keep from vault ${activeVault.name}`" type="button"
                  class="mdi mdi-close-circle text-danger fs-5"></i>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped>
.btn-primary {
  pointer-events: none;
}

i {
  position: relative;
  top: 0px;
  right: 25px;
}

.cover-img-bg {
  height: 40dvh;
  background-size: cover;
  background-position: center;
  border-radius: 5px;
}

.cover-img-text {
  text-shadow: 1px 1px 10px rgb(0, 0, 0);
}

.masonry-layout {
  column-count: 4;
  column-gap: 1rem;
  width: 100%;
}

.masonry-item {
  break-inside: avoid;
  margin-bottom: 1rem;
}

@media (max-width: 768px) {
  .masonry-layout {
    column-count: 3;
  }
}

@media (max-width: 550px) {
  .masonry-layout {
    column-count: 2;
  }
}
</style>