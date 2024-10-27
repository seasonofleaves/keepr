<script setup>
import { Keep } from '@/models/Keep.js';

defineProps({
  activeKeep: {type: Keep, required: true}
})

</script>


<template>
  <div class="container">
    <section class="row">
      <div class="col-6 p-0">
        <div class="img-style">
          <img class="" :src="activeKeep.img" :alt="activeKeep.name">
        </div>
      </div>
      <div class="col-6 p-3 d-flex flex-column justify-content-between align-items-center">
        <div class="d-flex align-items-center">
          <i class="mdi mdi-eye-outline p-2 fs-4"></i><span class="top-text fs-5">{{ activeKeep.views }}</span>
          <i class="mdi mdi-alpha-k-box-outline p-2 fs-4"></i><span class="fs-5">{{ activeKeep.kept }}</span>
        </div>
        <div class="d-flex flex-column align-items-center">
          <h4>{{ activeKeep.name }}</h4>
          <p>{{ activeKeep.description }}</p>
        </div>
        <div class="col-12 d-flex justify-content-between align-items-center">
          <div class="d-flex align-items-center">
            <div class="dropdown">
              <button class="btn dropdown-toggle" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
               Vault
             </button>
             <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                <a class="dropdown-item" href="#">Action</a>
                <a class="dropdown-item" href="#">Another action</a>
                <a class="dropdown-item" href="#">Something else here</a>
             </div>
            </div>
            <button class="btn btn-success mx-2">save</button>
          </div>
          <div class="d-flex align-items-center">
            <img class="avatar shadow mx-2" :src="activeKeep.creator.picture" :alt="activeKeep.creator.name">
            <p class="mb-0 text-break text-wrap">{{ activeKeep.creator.name }}</p>
          </div>
          </div>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped>
.avatar {
  vertical-align: middle;
  width: 40px;
  height: 40px;
  border-radius: 50%;
}

img{
  width: 100%;
  height: 70vh;
  object-fit: cover;
  object-position: center;
}
.top-text{
  padding-right: 30px;
}

.btn{
  padding-top: 1px;
  padding-bottom: 5px;
  border-radius: 10px;
}

</style>