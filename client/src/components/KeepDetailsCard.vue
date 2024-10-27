<script setup>
import { Keep } from '@/models/Keep.js';

defineProps({
  activeKeep: {type: Keep, required: true}
})

</script>


<template>
  <div class="container">
    <section class="row">
      <div class="col-6">
        <img class="img-fluid" :src="activeKeep.img" :alt="activeKeep.name">
      </div>
      <div class="col-6">
        <h1>{{ activeKeep.name }}</h1>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped>

</style>