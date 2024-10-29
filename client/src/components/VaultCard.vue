<script setup>
import { Vault } from '@/models/Vault.js';


const props = defineProps({
  vault: {type: Vault, required: true}
})

</script>


<template>
<div class="card">
  <img :src="props.vault.img" :alt="props.vault.name" :title="props.vault.name">
</div>
</template>


<style lang="scss" scoped>

</style>