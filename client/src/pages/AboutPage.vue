<script setup>

</script>

<template>
  <div class="container-fluid p-0">
    <div class="sectional light justify-content-evenly">
      <div class="width-50">
        <h1>About Keepr</h1>
        <p>Keepr is a vibrant social network designed for users to visually share and explore their passions through a
          dynamic collection of images. Keepr incorporates several innovative features that enhance user engagement,
          elevating the user experience through personalized Vaults, privacy settings, and an enhanced UI, creating a
          dynamic and engaging social platform for users to explore and share their passions.</p>
      </div>
      <div>
        <img src="../assets/img/keepr-logo.png" alt="Keepr logo" class="sectional-img">
      </div>
    </div>
    <div class="sectional justify-content-evenly">
      <div>
        <img src="../assets/img/vue-logo.png" alt="vue logo" class="sectional-img ms-md-3">
      </div>
      <div class="width-50 text-end">
        <h2>Concepts and Tools Used</h2>
        <p>Leverages Vue.js for responsive frontend elements and Vue-Router for seamless navigation. On the server side,
          DotNet WebApi, powered by Dapper as an ORM, ensures powerful backend capabilities. Authentication through
          Auth0 is seamless, allowing users to register, log in, and stay authenticated on page refresh. Comprehensive
          testing using an API testing suite ensures reliability, making Keepr a trustworthy platform for visual sharing
          and discovery.</p>
      </div>
    </div>
    <div class="sectional light justify-content-evenly">
      <div class="width-50">
        <h2>Key Features</h2>
        <h5>Vaults and Keeps</h5>
        <p>Users can create custom Vaults, thematic collections that house their Keeps (images). This unique feature
          enables users to curate and share their interests in an organized manner.</p>
        <h5>Privacy Settings</h5>
        <p>Vaults can be marked as private, offering a personalized and secure space for users. Only the
          creator has access to private Vaults, ensuring a more intimate and personalized experience.</p>
        <h5>View and Save Count</h5>
        <p>Keepr acknowledges and displays the popularity of Keeps by showing view counts. Additionally, the 'Kept'
          count increments each time a user adds a Keep to their Vault, providing recognition for engaging content.</p>
        <h5>User Profiles</h5>
        <p>Every user has a public profile page, showcasing their Keeps and Vaults. This adds a social
          dimension, allowing users to explore and connect based on shared interests.</p>
      </div>
      <div>
        <img src="../assets/img/keepr-logo.png" alt="Keepr logo" class="sectional-img">
      </div>
    </div>

    <!-- <div>
      <div class="sectional light">
        <div class="w-70">
          <h2 class="mb-4">Contributers</h2>
          <div class="d-flex align-items-center">
            <div>
              <img src="" alt="">
            </div>
            <div>
              <h4>Autumn Eckley</h4>
              <p>I first discovered my passion for web development my freshman year of high school while I was enrolled
                in the Oregon Coast Technical Program. I instantly fell in love with the art and process of coding, but
                I didn’t consider making it my career until 10 years later in 2023. Enrolling in the Boise Codeworks
                Fall 2024 Cohort was the best decision I could have made, and working on this application with such an
                incredible team has solidified my passion for software development. I am a bit of a work-a-holic, and
                frequently find myself with very little to no free time outside of my three jobs. When I am not
                deep-diving into government APIs, you can find me at home reading or cooking, playing board games or
                longboarding with friends, or planning my next big adventure overseas.
              </p>
              <h2>
                <a href="https://github.com/seasonofleaves">
                  <i class="mdi mdi-github"></i>
                </a>
                <a href="https://www.linkedin.com/in/autumneckley/">
                  <i class="mdi mdi-linkedin"></i>
                </a>
              </h2>
            </div>
          </div>
        </div>
      </div>
      <div class="sectional justify-content-end">
        <div class="w-70 text-end">
          <div>
            <h4>Matthew Marchal</h4>
            <p>I was initially introduced to web and software development in high school, and pursued it for a couple
              years after, but took an extended break from programming for many years. CodeWorks has been a huge help on
              my journey to refamiliarize myself with the development world and the Pocket Ranger site specifically has
              been a great opportunity to collaborate with others and practice with skills and technologies we all were
              interested in working with.</p>
            <h2>
              <a href="https://github.com/santyclause">
                <i class="mdi mdi-github"></i>
              </a>
              <a href="https://www.linkedin.com/in/matthewmarchal/">
                <i class="mdi mdi-linkedin"></i>
              </a>
            </h2>
          </div>
          <div>
            <img src="" alt="">
          </div>
        </div>
      </div>
      <div class="sectional light">
        <div class="w-70">
          <div>
            <img src="" alt="">
          </div>
          <div>
            <h4>Nigel Sprague</h4>
            <p>Hello, I am Nigel. Aside from learning web and software development skills, I am spending most of my time
              skateboarding, reading, or (most likely) working in filmmaking and the arts. With a passion for
              storytelling, a deep appreciation for the visual, and an ever expanding development toolset, I am excited
              to see where I can take the skills I have learned from the fall 2024 Codeworks cohort. Pocket Ranger
              allowed me to work both collaboratively and creatively on a team, gaining a better understanding of a
              project's journey from start to finish. Thank you to the Codeworks instructors, and to you for visiting
              our
              page.</p>
            <h2>
              <a href="https://github.com/nigelsprague">
                <i class="mdi mdi-github"></i>
              </a>
              <a href="https://www.linkedin.com/in/nigelsprague/">
                <i class="mdi mdi-linkedin"></i>
              </a>
            </h2>
          </div>
        </div>
      </div>
    </div> -->
  </div>

</template>

<style scoped lang="scss">
.sectional {
  display: flex;
  align-items: center;
  padding: 2em;
}

.sectional-img {
  max-width: 20vw;
}

.light {
  background-color: var(--offwhite);
}

.w-70 {
  width: 70%;
}

.width-50 {
  width: 50%;
}

@media (max-width: 768px) {
  .sectional {
    flex-direction: column;
  }

  .width-50 {
    width: 70%;
  }
}

@media (max-width: 550px) {
  .w-70 {
    width: 100%;
  }

  .width-50 {
    width: 100%;
  }
}
</style>