<script setup>
import { computed, onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
import ModalWrapper from './ModalWrapper.vue';
import KeepForm from './KeepForm.vue';
import VaultForm from './VaultForm.vue';
import { AppState } from '@/AppState.js';

const theme = ref(loadState('theme') || 'light')
const account = computed(() => AppState.account)

onMounted(() => {
  document.documentElement.setAttribute('data-bs-theme', theme.value)
})

function toggleTheme() {
  theme.value = theme.value == 'light' ? 'dark' : 'light'
  document.documentElement.setAttribute('data-bs-theme', theme.value)
  saveState('theme', theme.value)
}

</script>

<template>
  <nav class="navbar navbar-expand-sm navbar-dark bg-page px-3 shadow-sm">
    <!-- <div class="">
      <img class="" src="/src/assets/img/keepr-logo.png" alt="">
    </div> -->
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <h5 title="Home Page" class="btn bg-info">Home</h5>
      </div>
    </router-link>
    <button class="navbar-toggler bg-success" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li>
          <router-link :to="{ name: 'About' }" title="About Page"
            class="btn text-dark lighten-30 selectable text-uppercase">
            About
          </router-link>
        </li>
        <li v-if="account">
          <div class="dropdown">
            <button title="Click to create vault or keep" class="btn text-dark dropdown-toggle" type="button"
              id="dropdownMenuButton" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
              Create
            </button>
            <div class="dropdown-menu bg-primary" aria-labelledby="dropdownMenuButton">
              <div data-bs-toggle="modal" data-bs-target="#keep-form">
                <button title="Keep" class="dropdown-item">Keep</button>
              </div>
              <div data-bs-toggle="modal" data-bs-target="#vault-form">
                <button title="Vault" class="dropdown-item">Vault</button>
              </div>
            </div>
          </div>
        </li>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <div>
        <button class="btn text-success" @click="toggleTheme"
          :title="`Enable ${theme == 'light' ? 'dark' : 'light'} theme.`">
          <Icon :name="theme == 'light' ? 'weather-sunny' : 'weather-night'" />
        </button>
      </div>
      <Login />
    </div>
  </nav>
</template>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}

.bg-primary {
  border-color: #877A8F;
  border-width: 3px;
}

/* 
img{
  aspect-ratio: 1/1;
  height: 50px;
} */
</style>
