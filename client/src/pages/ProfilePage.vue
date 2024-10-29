<script setup>
import { AppState } from '@/AppState.js';
import { keepsService } from '@/services/KeepsService.js';
import { profilesService } from '@/services/ProfilesService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';


const route = useRoute()
const profile = computed(() => AppState.activeProfile)

onMounted(() => {
  getProfileById()
  getKeepsByProfileId()
})

async function getProfileById(){
  try {
    const profileId = route.params.profileId
    logger.log('Id of the profile from the URL', profileId)
    await profilesService.getProfileById(profileId)
  }
  catch (error){
    Pop.error(error)
    logger.log(error)
  }
}

async function getKeepsByProfileId(){
  try {
    const profileId = route.params.profileId
    await keepsService.getKeepsByProfileId(profileId)
  }
  catch (error){
    Pop.error(error)
    logger.log(error)
  }
}

</script>


<template>
<div v-if="profile" class="container">
  <br>
  <section class="row justify-content-center">
    <div class="col-7 cover-img-bg align-content-end" :style="{backgroundImage:`url(${profile.coverImg})`}">
      <div class="d-flex justify-content-center">
        <img class="avatar" :src="profile.picture" :alt="profile.name">
      </div>
    </div>
    <div class="col-12">
      <div class="d-flex justify-content-center mt-5">
        <h3>{{ profile.name }}</h3>
      </div>
    </div>
  </section>
</div>
</template>


<style lang="scss" scoped>
.cover-img-bg{
  height: 30dvh;
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
  box-shadow:  0px 5px 10px rgb(149, 148, 148);
}
</style>