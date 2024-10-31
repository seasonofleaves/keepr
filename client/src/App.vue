<script setup>
import Navbar from './components/Navbar.vue';
import { AppState } from './AppState.js';
import ModalWrapper from './components/ModalWrapper.vue';
import KeepDetailsCard from './components/KeepDetailsCard.vue';
import { computed } from 'vue';

const activeKeep = computed(() => AppState.activeKeep)

</script>

<template>
  <ModalWrapper id="keep-details">
    <KeepDetailsCard v-if="activeKeep" :activeKeep />
  </ModalWrapper>
  <header class="sticky-lg-top bg-light">
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="bg-page text-dark">
  </footer>
</template>

<style lang="scss">
@import '@/assets/scss/main.scss';

:root {
  --main-height: calc(100vh - 32px - 64px);
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}

#keep-details .modal-body {
  padding: 0;
}

#keep-details .modal-content {
  border: none;
}
</style>
