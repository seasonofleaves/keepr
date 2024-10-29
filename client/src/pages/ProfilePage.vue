<script setup>
import { AppState } from '@/AppState.js';
import { profilesService } from '@/services/ProfilesService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';


const route = useRoute()
const profile = computed(() => AppState.activeProfile)

onMounted(() => {
  getProfileById()
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

</script>


<template>
<h1>Profile Page</h1>
<div class="container">
  <section class="row">
    <div class="col-12">
      {{ profile }}
    </div>
  </section>
</div>
</template>


<style lang="scss" scoped>

</style>