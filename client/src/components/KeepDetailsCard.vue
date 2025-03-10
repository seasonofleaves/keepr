<script setup>
import { AppState } from '@/AppState.js';
import { Keep } from '@/models/Keep.js';
import { vaultKeepsService } from '@/services/VaultKeepsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { computed, ref, useTemplateRef } from 'vue';
// @ts-ignore
import placeholder from '../assets/img/no-image-placeholder-bg-text.png'

const myVaults = computed(() => AppState.myVaults)
const account = computed(() => AppState.account)

const vaultKeepData = ref({
  vaultId: 0,
  keepId: 0
})

const props = defineProps({
  activeKeep: { type: Keep, required: true }
})

const img = useTemplateRef('keep-img')

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

//NOTE - N will stop the page from glitching (flashing) if the placeholder image doesnt import properly
let n = 0

function setPlaceholder() {
  n++
  if (n > 3) {
    return
  }
  img.value.setAttribute('src', placeholder)
}

</script>


<template>
  <div class="container">
    <section class="row">
      <div class="col-12 col-lg-6 p-0">
        <div class="img-style">
          <img ref="keep-img" @error="setPlaceholder" :title="`Image for ${activeKeep.name}`" :src="activeKeep.img"
            :alt="activeKeep.name">
          <div class="align-self-start card-img-overlay text-end">
            <button @click="closeModal()" title="Close keep"
              class="text-end m-1 text-bg-light ms-auto btn-close"></button>
          </div>
        </div>
      </div>
      <div class=" col-12 col-lg-6 p-3 d-flex flex-column justify-content-between align-items-center">
        <div class="d-flex align-items-center">
          <i title="Views" class="mdi mdi-eye-outline p-2 fs-5"></i><span :title="activeKeep.views" class="top-text">{{
            activeKeep.views }}</span>
          <i title="Number of times keep has been kept" class="mdi mdi-alpha-k-box-outline p-2 fs-5"></i><span
            :title="activeKeep.kept">{{
              activeKeep.kept
            }}</span>
        </div>
        <div class="d-flex flex-column align-items-center px-3">
          <h4 :title="activeKeep.name">{{ activeKeep.name }}</h4>
          <p :title="activeKeep.description" class="text-center">{{ activeKeep.description }}</p>
        </div>
        <div class="col-12 d-flex justify-content-between align-items-center">
          <div class="d-flex align-items-center">
            <form v-if="account" @submit.prevent="createVaultKeep()">
              <select title="select a vault" v-model="vaultKeepData.vaultId" class="btn dropdown-toggle"
                aria-label="Select a Vault" required>
                <option selected :value="0" disabled>Vault</option>
                <option v-for="vault in myVaults" :key="vault.id" :value="vault.id">{{ vault.name }}</option>
              </select>
              <button title="save to vault" type="submit" class="btn btn-success mx-2 text-light">save</button>
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

@media (max-width: 550px) {
  img {
    max-height: 50vh;
  }
}

img {
  width: 100%;
  height: 65vh;
  object-fit: cover;
  object-position: center;
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
  background-color: -bs-var-page;
}
</style>