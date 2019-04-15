<template>
  <div class="home">
    <div class="row">
      <div class="col-12">
        <div class="dropdown col-1 line ml-1 mt-1">
          <i
            class="fas fa-bars d-flex"
            type="button"
            id="dropdownMenuButton"
            data-toggle="dropdown"
            aria-haspopup="true"
            aria-expanded="false"
          ></i>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <div v-if="homePage">
              <a @click="profile" class="dropdown-item">Profile</a>
              <div class="dropdown-divider"></div>
            </div>
            <div v-if="!homePage">
              <a @click="home" class="dropdown-item">Home Page</a>
              <div class="dropdown-divider"></div>
            </div>
            <div>
              <a @click="logOut()" class="dropdown-item">logout</a>
            </div>
          </div>
        </div>
        <h1>Welcome to Keepr</h1>
      </div>
    </div>
    <button
      type="button"
      class="btn btn-primary createKeep"
      data-toggle="modal"
      data-target="#createKeepModal"
    >Create a Keep</button>
    <createKeep></createKeep>

    <keeps class="ml-2 mt-2" v-for="keep in keeps" :keepData="keep" :key="keep._id"></keeps>
  </div>
</template>

<script>
import keeps from "@/components/keeps.vue";
import createKeep from "@/components/createKeep.vue";

export default {
  name: "home",
  mounted() {
    //blocks users not logged in
    if (!this.$store.state.user.id) {
      this.$router.push({ name: "login" });
    } else {
      this.$store.dispatch("getKeeps");
    }
  },
  computed: {
    userId() {
      return this.$store.state.user.id;
    },
    keeps() {
      return this.$store.state.keeps;
    },
    homePage() {
      return this.$route.name == "#";
    },
    home() {
      this.$router.push({ name: "home" });
    },
    logOut() {
      this.$store.dispatch("logOut");
    },
    profile() {
      if (userId) {
        this.$router.push({ name: "profile" });
      }
    }
  },
  components: {
    keeps,
    createKeep
  }
};
</script>
<style>
.createKeep {
  cursor: pointer;
}
</style>
