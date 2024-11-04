<script setup>
import { AppState } from '@/AppState.js';
import KeepCard from '@/components/KeepCard.vue';
import VaultCard from '@/components/VaultCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import { profilesService } from '@/services/ProfilesService.js';
import { vaultsService } from '@/services/VaultsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, watch } from 'vue';
import { useRoute } from 'vue-router';


const route = useRoute()
const profile = computed(() => AppState.activeProfile)
const keeps = computed(() => AppState.keeps)
const vaults = computed(() => AppState.vaults)

watch(() => route.params.profileId, () => {
  getProfileById()
  getKeepsByProfileId()
  getVaultsByProfileId()
  AppState.activeVault == null
}, { immediate: true })

async function getProfileById() {
  try {
    const profileId = route.params.profileId
    logger.log('Id of the profile from the URL', profileId)
    await profilesService.getProfileById(profileId)
  }
  catch (error) {
    Pop.error(error)
    logger.log(error)
  }
}

async function getKeepsByProfileId() {
  try {
    const profileId = route.params.profileId
    await keepsService.getKeepsByProfileId(profileId)
  }
  catch (error) {
    Pop.error(error)
    logger.log(error)
  }
}

async function getVaultsByProfileId() {
  try {
    const profileId = route.params.profileId
    await vaultsService.getVaultsByProfileId(profileId)
  }
  catch (error) {
    Pop.error(error)
    logger.log(error)
  }
}

</script>


<template>
  <!-- NOTE HEADER -->
  <div v-if="profile" class="container">
    <br>
    <section class="row justify-content-center">
      <div :title="`${profile.name}'s cover image`" class="col-8 cover-img-bg align-content-end"
        :style="{ backgroundImage: `url(${profile.coverImg})` }">
        <div class="d-flex justify-content-center">
          <img :title="`${profile.name}'s profile picture`" class="avatar" :src="profile.picture" :alt="profile.name">
        </div>
      </div>
      <div class="col-12 d-flex justify-content-center">
        <div class="d-flex flex-column text-center mt-5">
          <h3 :title="profile.name" class="fw-bold">{{ profile.name }}</h3>
          <p><span :title="`${profile.name} has ${vaults.length} vaults`">{{ vaults.length }} Vaults</span> | <span
              :title="`${profile.name} has ${keeps.length} keeps`">{{
                keeps.length }} Keeps</span></p>
        </div>
      </div>
    </section>
  </div>

  <!-- NOTE VAULTS -->
  <div class="container mb-3">
    <section class="row">
      <div class="d-flex justify-content-center">
        <div class="col-12 col-md-10 mb-3">
          <h4 :title="`${profile.name}'s vaults`" class="mb-3">Vaults</h4>
          <div class="masonry-layout">
            <div class="masonry-item" v-for="vault in vaults" :key="vault.id">
              <VaultCard :vault="vault" />
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>

  <!-- NOTE KEEPS -->
  <div class="container mb-3">
    <section class="row">
      <div class="d-flex justify-content-center">
        <div class="col-12 col-md-10 mb-3">
          <h4 :title="`${profile.name}'s keeps`" class="mb-3">Keeps</h4>
          <div class="masonry-layout">
            <div class="masonry-item" v-for="keep in keeps" :key="keep.id">
              <KeepCard :keep="keep" />
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped>
.cover-img-bg {
  height: 40dvh;
  background-size: cover;
  background-position: center;
  border-radius: 5px;
}

.avatar {
  position: relative;
  top: 40px;
  width: 80px;
  height: 80px;
  border-radius: 50%;
  border-width: 1px;
  border-color: #F9F6FA;
  border-style: solid;
  object-fit: cover;
  object-position: center;
  box-shadow: 0px 5px 10px rgb(149, 148, 148);
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

@media (max-width: 992px) {
  .masonry-layout {
    column-count: 3;
  }
}

@media (max-width: 480px) {
  .masonry-layout {
    column-count: 2;
  }
}
</style>