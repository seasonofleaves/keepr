<script setup>
import { AppState } from '@/AppState.js';
import { Vault } from '@/models/Vault.js';
import { computed } from 'vue';

const account = computed(() => AppState.account)
// const activeVault = computed(() => AppState.activeVault)

const props = defineProps({
  vault: {type: Vault, required: true}
})

</script>


<template>
  <router-link :to="{name: 'Vault', params: {vaultId: vault.id}}">
    <div class="card text-bg-dark">
      <img class="img-fluid" height="500" width="500" :src="props.vault.img" :alt="props.vault.name" :title="props.vault.name">
      <div class="card-img-overlay d-flex flex-column justify-content-between">
        <div class="d-flex justify-content-end">
          <i v-if="props.vault.creatorId == account?.id" type="button" class="mdi mdi-close-circle text-danger fs-5"></i>
        </div>
        <div class="d-flex align-items-center justify-content-between">
          <p class="card-text m-0">{{ props.vault.name }}</p>
          <i v-if="props.vault.isPrivate" class="mdi mdi-lock" title="vault is private"></i>
        </div>
      </div>
    </div>
  </router-link>
</template>


<style lang="scss" scoped>
.img-fluid{
  border-radius: 5px;
  min-height: 110px;
  object-fit: cover;
  object-position: center;
}

p{
  font-weight: bold;
  text-shadow: 1px 1px 10px rgb(0, 0, 0);
}

.mdi-close-circle{
  position: relative;
  bottom: 15px;
  left: 10px;
}

.card{
  min-height: 110px;
  border: none;
  box-shadow: 1px 1px 10px rgb(67, 67, 67);
}

@media (min-width: 768px) {
  p{
    font-size: larger;
  }
}

@media (max-width: 480px) {
  p{
    font-size: small;
  }
}

</style>