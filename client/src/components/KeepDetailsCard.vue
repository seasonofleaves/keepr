<script setup>
import { AppState } from '@/AppState.js';
import { Keep } from '@/models/Keep.js';
import { vaultKeepsService } from '@/services/VaultKeepsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { computed, ref } from 'vue';

const myVaults = computed(() => AppState.myVaults)
const account = computed(() => AppState.account)

const vaultKeepData = ref({
  vaultId: 0,
  keepId: 0
})

const props = defineProps({
  activeKeep: { type: Keep, required: true }
})

async function createVaultKeep() {
  try {
    const keepId = props.activeKeep.id
    vaultKeepData.value.keepId = keepId
    await vaultKeepsService.createVaultKeep(vaultKeepData.value)
    vaultKeepData.value = {
      vaultId: 0,
      keepId: 0
    }
  }
  catch (error) {
    Pop.error(error)
    logger.log(error)
  }
}

function closeModal() {
  Modal.getOrCreateInstance('#keep-details').hide()
}

</script>


<template>
  <div class="container">
    <section class="row">
      <div class="col-12 col-lg-6 p-0">
        <div class="img-style">
          <img class="" :src="activeKeep.img" :alt="activeKeep.name">
        </div>
      </div>
      <div class="col-12 col-lg-6 p-3 d-flex flex-column justify-content-between align-items-center">
        <div class="d-flex align-items-center">
          <i class="mdi mdi-eye-outline p-2 fs-5"></i><span class="top-text ">{{ activeKeep.views }}</span>
          <i class="mdi mdi-alpha-k-box-outline p-2 fs-5"></i><span class="">{{ activeKeep.kept }}</span>
        </div>
        <div class="d-flex flex-column align-items-center px-3">
          <h4>{{ activeKeep.name }}</h4>
          <p class="text-center">{{ activeKeep.description }}</p>
        </div>
        <div class="col-12 d-flex justify-content-between align-items-center">
          <div class="d-flex align-items-center">
            <form v-if="account" @submit.prevent="createVaultKeep()">
              <select v-model="vaultKeepData.vaultId" class="btn dropdown-toggle" aria-label="Select a Vault" required>
                <option selected :value="0" disabled>Vault</option>
                <option v-for="vault in myVaults" :key="vault.id" :value="vault.id">{{ vault.name }}</option>
              </select>
              <button type="submit" class="btn btn-success mx-2 text-light">save</button>
            </form>
          </div>
          <div class="d-flex align-items-center">
            <router-link @click="closeModal()" :to="{ name: 'Profile', params: { profileId: activeKeep.creatorId } }"
              :title="`Go to ${activeKeep.creator.name}'s profile page!`">
              <img data-bs-dismiss="modal" class="avatar shadow mx-2" :src="activeKeep.creator.picture"
                :alt="activeKeep.creator.name">
            </router-link>
            <p class="mb-0 text-break text-wrap">{{ activeKeep.creator.name }}</p>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped>
select {
  border: 0;
  outline: none !important;
}

.avatar {
  vertical-align: middle;
  width: 40px;
  height: 40px;
  border-radius: 50%;
}

@media (max-width: 480px) {
  img {
    max-height: 50vh;
  }
}

img {
  width: 100%;
  height: 65vh;
  object-fit: cover;
  object-position: center;
  border-start-start-radius: 6px;
  border-end-start-radius: 6px;
}

.top-text {
  padding-right: 10px;
}

.btn {
  padding-top: 1px;
  padding-bottom: 5px;
  border-radius: 10px;
}

.container {
  background-color: #FEF6F0;
}
</style>