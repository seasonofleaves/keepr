<script setup>
import { keepsService } from '@/services/KeepsService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { ref } from 'vue';

const editableKeepData = ref({
  name: '',
  description: '',
  img: ''
})

async function createKeep() {
  try {
    await keepsService.createKeep(editableKeepData.value)
    editableKeepData.value = {
      name: '',
      description: '',
      img: ''
    }
  }
  catch (error) {
    Pop.error(error)
    logger.log(error)
  }
}

function closeModal() {
  Modal.getOrCreateInstance('#keep-form').hide()
}

</script>


<template>
  <div class="container">
    <section class="row">
      <div class="col-12">
        <h1>Add your keep</h1>
        <form @submit.prevent="createKeep()">
          <div class="form-group mt-4">
            <input v-model="editableKeepData.name" type="text" class="form-control" id="title" placeholder="Title..."
              minlength="5" maxlength="20" required>
          </div>
          <div class="form-group mt-2">
            <input v-model="editableKeepData.img" type="url" class="form-control" id="imgUrl" placeholder="Image URL..."
              minlength="60" maxlength="1000" required>
          </div>
          <div class="form-group mt-2">
            <textarea v-model="editableKeepData.description" rows="8" type="text" class="form-control" id="description"
              placeholder="Keep Description..." minlength="5" maxlength="1000" required></textarea>
          </div>
          <div class="text-end mt-2">
            <button @click="closeModal()" type="submit" class="btn btn-dark">Create</button>
          </div>
        </form>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped>
.btn {
  padding-top: 1px;
  padding-bottom: 5px;
  border-radius: 10px;
}
</style>