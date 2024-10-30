<script setup>

</script>


<template>
  <!-- updateAccount() -->

  <div class="container">
    <section class="row g-3">
      <div class="col-12">
        <h1>Update your profile</h1>
        <form @submit.prevent="">
          <div class="form-group mt-4">
            <input type="text" class="form-control" id="name" placeholder="Name..." minlength="5" maxlength="30"
              required>
          </div>
          <div class="form-group mt-2">
            <input type="url" class="form-control" id="profilePictureUrl" placeholder="Profile Picture URL..."
              minlength="100" maxlength="1000" required>
          </div>
          <div class="form-group mt-2">
            <input type="url" class="form-control" id="coverImgUrl" placeholder="Cover Image URL..." minlength="100"
              maxlength="1000" required>
          </div>
          //TODO - Add bio?
          <!-- <div class="form-group mt-2">
            <textarea  rows="8" type="text" class="form-control" id="bio"
              placeholder="Your bio..." minlength="5" maxlength="1000"></textarea>
          </div> -->
          <div class="text-end mt-2">
            <button type="submit" class="btn btn-dark">Create</button>
          </div>
        </form>
      </div>
    </section>
  </div>
</template>


<style lang="scss" scoped></style>