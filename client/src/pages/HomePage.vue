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

async function getAllKeeps() {
  try {
    await keepsService.getAllKeeps()
  }
  catch (error) {
    Pop.error(error)
    logger.log(error)
  }
}

</script>

<template>
<div class="bg-secondary p-1"></div>
  <div class="container-fluid mt-5 mb-3">
    <section class="row">
      <div class="col-12">
        <div class="masonry-layout">
          <div class="masonry-item" v-for="keep in keeps" :key="keep.id">
            <KeepCard :keep />
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
