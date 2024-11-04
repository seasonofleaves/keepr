<script setup>
import { AppState } from '@/AppState.js';
import { Vault } from '@/models/Vault.js';
import { vaultsService } from '@/services/VaultsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, useTemplateRef } from 'vue';
// @ts-ignore
import placeholder from '../assets/img/no-image-placeholder-bg-text.png'

const account = computed(() => AppState.account)
const img = useTemplateRef('vault-img')

const props = defineProps({
  vault: { type: Vault, required: true }
})

async function deleteVault() {
  try {
    const wantsToDelete = await Pop.confirm(`Are you sure you want to delete this vault?`)
    if (!wantsToDelete) return
    await vaultsService.deleteVault(props.vault.id, props.vault.name)
  }
  catch (error) {
    Pop.error(error)
    logger.log(error)
  }
}

function setPlaceholder() {
  img.value.setAttribute('src', placeholder)
}

</script>


<template>
  <div :title="`Go to ${props.vault.name} page!`" class="card position-relative text-bg-dark">
    <button class="btn __delete" title="Delete vault" @click="deleteVault">
      <i v-if="props.vault.creatorId == account?.id" class="mdi mdi-close-circle text-danger fs-5" />
    </button>
    <router-link class="__link" :to="{ name: 'Vault', params: { vaultId: vault.id } }">
      <img ref="vault-img" @error="setPlaceholder" class="img-fluid" height="500" width="500" :src="props.vault.img"
        :alt="props.vault.name" :title="props.vault.name">
      <div class="card-img-overlay d-flex flex-column justify-content-end">
        <div class="d-flex align-items-center justify-content-between">
          <p class="card-text m-0">{{ props.vault.name }}</p>
          <i v-if="props.vault.isPrivate" class="text-dark mdi mdi-lock" title="Vault is private"></i>
        </div>
      </div>
    </router-link>
  </div>
</template>


<style lang="scss" scoped>
.text-dark {
  background-color: #F9F6FA;
  border-radius: 50%;
  padding-left: 4px;
  padding-right: 4px;
  // height: 25px;
  // width: 25px;
}

.img-fluid {
  border-radius: 5px;
  min-height: 110px;
  object-fit: cover;
  object-position: center;
}

a {
  color: unset;
}

p {
  font-weight: bold;
  text-shadow: 1px 1px 10px rgb(0, 0, 0);
}

.__delete {
  position: absolute;
  right: 0px;
  z-index: 2;
}

.card {
  min-height: 110px;
  border: none;
  box-shadow: 1px 1px 10px rgb(67, 67, 67);
}

@media (min-width: 768px) {
  p {
    font-size: larger;
  }
}

@media (max-width: 550px) {
  p {
    font-size: medium;
  }
}
</style>