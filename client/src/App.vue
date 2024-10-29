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
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
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

#keep-details .modal-body{
  padding: 0;
}

#keep-details .modal-content{
  border: none;
}
</style>
