<script setup>
import { AppState } from '@/AppState.js';
import { Keep } from '@/models/Keep.js';
import { keepsService } from '@/services/KeepsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { computed, useTemplateRef } from 'vue';
// @ts-ignore
import placeholder from '../assets/img/no-image-placeholder-bg-text.png'

const account = computed(() => AppState.account)
const img = useTemplateRef('keep-img')

const props = defineProps({
  keep: { type: Keep, required: true }
})

async function setActiveKeep() {
  try {
    keepsService.setActiveKeep(props.keep)
    await keepsService.getKeepById(props.keep.id)
    // open modal
    Modal.getOrCreateInstance('#keep-details').show()
  }
  catch (error) {
    Pop.error(error)
    logger.log(error)
  }
}

async function deleteKeep() {
  try {
    const wantsToDelete = await Pop.confirm(`Are you sure you want to delete this keep?`)
    if (!wantsToDelete) return
    await keepsService.deleteKeep(props.keep.id, props.keep.name)
  }
  catch (error) {
    Pop.error(error)
    logger.log(error)
  }
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
  <div @click="setActiveKeep()" :title="`Click on ${props.keep.name} to see details`" class="card text-bg-dark">
    <img ref="keep-img" @error="setPlaceholder" class="img-fluid" height="500" width="500" :src="props.keep.img"
      :alt="props.keep.name">
    <div class="card-img-overlay d-flex flex-column justify-content-between">
      <div class="d-flex justify-content-end">
        <i v-if="props.keep.creatorId == account?.id" @click.stop="deleteKeep()" title="Delete keep" type="button"
          class="mdi mdi-close-circle text-danger fs-5"></i>
      </div>
      <div class="d-flex align-items-center justify-content-between text-wrap">
        <p class="card-text">{{ props.keep.name }}</p>
        <img class="avatar shadow" :title="props.keep.creator.name" :src="props.keep.creator.picture"
          :alt="props.keep.creator.name">
      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped>
i {
  position: relative;
  bottom: 15px;
  left: 10px;
}

p {
  font-weight: bold;
  text-shadow: 1px 1px 10px rgb(0, 0, 0);
  margin-right: 1rem;
  margin-bottom: 0;
}

.card {
  min-height: 110px;
  border: none;
  box-shadow: 1px 1px 10px rgb(67, 67, 67);
}

.img-fluid {
  border-radius: 5px;
  min-height: 110px;
  object-fit: cover;
  object-position: center;
}

.avatar {
  vertical-align: middle;
  aspect-ratio: 1/1;
  width: 40px;
  height: 40px;
  border-radius: 50%;
  object-fit: cover;
  object-position: center;
}

@media (min-width: 768px) {
  p {
    font-size: medium;
  }
}

@media (max-width: 550px) {
  p {
    font-size: medium;
  }
}
</style>