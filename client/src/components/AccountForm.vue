<script setup>
import { AppState } from '@/AppState.js';
import { accountService } from '@/services/AccountService.js';
import { logger } from '@/utils/Logger.js';
import Pop from '@/utils/Pop.js';
import { onMounted, ref } from 'vue';

const editableProfileData = ref({
  name: '',
  picture: '',
  coverImg: ''
})

onMounted(() => {
  editableProfileData.value = { ...AppState.account }
})

async function updateAccount() {
  try {
    await accountService.updateAccount(editableProfileData.value)
    Pop.success("Changes saved to your account!")
  }
  catch (error) {
    Pop.error(error)
    logger.log(error)
  }
}

</script>


<template>
  
  <div class="container">
    <section class="row g-3">
      <div class="col-12">
        <h1>Update your profile</h1>
        <form @submit.prevent="updateAccount()">
          <div class="form-group mt-4">
            <input v-model="editableProfileData.name" type="text" class="form-control" id="accountName"
              placeholder="Name..." minlength="5" maxlength="30" required>
          </div>
          <div class="form-group mt-2">
            <input v-model="editableProfileData.picture" type="url" class="form-control" id="profilePictureUrl"
              placeholder="Profile Picture URL..." minlength="60" maxlength="1000" required>
          </div>
          <div class="form-group mt-2">
            <input v-model="editableProfileData.coverImg" type="url" class="form-control" id="coverImgUrl"
              placeholder="Cover Image URL..." minlength="60" maxlength="1000" required>
          </div>
          <!-- //TODO - Add bio? -->
          <!-- <div class="form-group mt-2">
            <textarea  rows="8" type="text" class="form-control" id="bio"
              placeholder="Your bio..." minlength="5" maxlength="1000"></textarea>
          </div> -->
          <div class="text-end mt-2">
            <button type="submit" class="btn btn-dark">Update</button>
          </div>
        </form>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped></style>