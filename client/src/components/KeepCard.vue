<script setup>
import { Keep } from '@/models/Keep.js';
import { keepsService } from '@/services/KeepsService.js';


const props = defineProps({
  keep: {type: Keep, required: true}
})

function setActiveKeep(){
  keepsService.setActiveKeep(props.keep)
}

</script>


<template>
  <div class="card text-bg-dark">
    <img class="img-fluid" :src="keep.img" :alt="keep.name" :title="keep.name">
    <div class="card-img-overlay d-flex align-items-end justify-content-between">
      <p class="card-text fs-5 m-0">{{ keep.name }}</p>
      <img class="avatar shadow" :src="keep.creator.picture" :alt="keep.creator.name">
    </div>
  </div>

  

</template>


<style lang="scss" scoped>
p{
  font-weight: bold;
  text-shadow: 1px 1px 10px rgb(0, 0, 0);
}

.card{
  --bs-card-border-radius: unset;
  border: none;
  box-shadow: 1px 1px 10px rgb(67, 67, 67);
}

.avatar {
  vertical-align: middle;
  width: 40px;
  height: 40px;
  border-radius: 50%;
}
</style>