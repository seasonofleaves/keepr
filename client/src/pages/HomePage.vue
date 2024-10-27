<script setup>
import { AppState } from '@/AppState.js';
import KeepCard from '@/components/KeepCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';

const keeps = computed(() => AppState.keeps)

onMounted(() => {
  getAllKeeps()
})

async function getAllKeeps(){
  try {
    await keepsService.getAllKeeps()
  }
  catch (error){
    Pop.error(error)
    logger.log(error)
  }
}

</script>

<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12">
        <div class="masonry-layout">
          <div class="masonry-item" v-for="keep in keeps" :key="keep.id">
            <KeepCard :keep="keep"/>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<style scoped lang="scss">
.masonry-layout {
  column-count: 4;
  column-gap: 1rem;
  width: 100%;
}

.masonry-item {
  break-inside: avoid;
  margin-bottom: 1rem;
}

@media (max-width: 480px) {
  .masonry-layout {
    column-count: 2;
  }
}
</style>
