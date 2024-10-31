<script setup>
import { vaultsService } from '@/services/VaultsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { ref } from 'vue';

const editableVaultData = ref({
  name: '',
  description: '',
  img: '',
  isPrivate: false,
})

async function createVault() {
  try {
    await vaultsService.createVault(editableVaultData.value)
    editableVaultData.value = {
      name: '',
      description: '',
      img: '',
      isPrivate: false,
    }
  }
  catch (error) {
    Pop.error(error)
    logger.log(error)
  }
}

function closeModal() {
  Modal.getOrCreateInstance('#vault-form').hide()
}

</script>


<template>
  <div class="container">
    <div class="section row">
      <div class="col-12">
        <h1>Add your vault</h1>
        <form @submit.prevent="createVault()">
          <div class="form-group mt-4">
            <input v-model="editableVaultData.name" type="text" class="form-control" id="title" placeholder="Title..."
              minlength="5" maxlength="20" required>
          </div>
          <div class="form-group mt-2">
            <input v-model="editableVaultData.img" type="url" class="form-control" id="imgUrl"
              placeholder="Image URL..." minlength="60" maxlength="1000" required>
          </div>
          <div class="form-group mt-2">
            <textarea v-model="editableVaultData.description" rows="8" type="text" class="form-control" id="description"
              placeholder="Vault Description..." minlength="5" maxlength="1000" required></textarea>
          </div>
          <div class="text-end mt-2">
            <label for="vault-privacy">*Private Vaults can only be seen by you</label>
            <div class="form-check d-flex fs-5 justify-content-end">
              <input v-model="editableVaultData.isPrivate" type="checkbox" class="form-check-input mx-2"
                id="vault-privacy">
              <label class="form-check-label" for="vault-privacy">Make Vault Private?</label>
            </div>
            <button @click="closeModal()" type="submit" class="btn btn-dark">Create</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.btn {
  padding-top: 1px;
  padding-bottom: 5px;
  border-radius: 10px;
}
</style>