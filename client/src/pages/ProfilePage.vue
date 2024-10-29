<script setup>
import { profilesService } from '@/services/ProfilesService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { onMounted } from 'vue';
import { useRoute } from 'vue-router';


const route = useRoute()

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
</template>


<style lang="scss" scoped>

</style>