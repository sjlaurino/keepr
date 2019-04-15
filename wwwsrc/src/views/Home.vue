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
              <a @click="logOut" class="dropdown-item">logout</a>
            </div>
          </div>
        </div>
        <h1>Welcome to Keepr</h1>
      </div>
    </div>
    <button
      v-if="userId"
      type="button"
      class="inline btn btn-primary createKeep"
      data-toggle="modal"
      data-target="#createKeepModal"
    >Create a Keep</button>
    <createKeep></createKeep>
    <button
      v-if="userId"
      type="button"
      class="inline btn btn-primary createKeep"
      data-toggle="modal"
      data-target="#createVaultModal"
    >Create a Vault</button>
    <createKeep></createKeep>
    <createVault></createVault>

    <keeps class="ml-2 mt-2" v-for="keep in keeps" :keepData="keep" :key="keep._id"></keeps>
  </div>
</template>

<script>
import keeps from "@/components/keeps.vue";
import createKeep from "@/components/createKeep.vue";
import createVault from "@/components/createVault.vue";

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
      return this.$route.name == "home";
    }
  },
  methods: {
    logOut() {
      this.$store.dispatch("logOut");
    },
    home() {
      this.$router.push({ name: "home" });
    },
    profile() {
      if (this.$store.state.user.id) {
        this.$router.push({ name: "profile" });
      }
    }
  },
  components: {
    keeps,
    createKeep,
    createVault
  }
};
</script>
<style>
.createKeep {
  cursor: pointer;
}
</style>
<style>
.dropdown-item {
  cursor: pointer;
}
.inline {
  display: inline-block;
}
</style>
