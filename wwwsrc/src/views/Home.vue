<template>
  <div class="home container">
    <nav class="col-12 navbar">
      <div class="dropdown line mt-1">
        <i
          class="fas fa-bars fa-2x"
          id="dropdownMenuButton"
          data-toggle="dropdown"
          aria-haspopup="true"
          aria-expanded="false"
        ></i>
        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
          <div v-if="homePage && userId">
            <a @click="profile" class="dropdown-item">Profile</a>
            <div class="dropdown-divider"></div>
          </div>
          <div v-if="!homePage">
            <a @click="home" class="dropdown-item">Home Page</a>
            <div class="dropdown-divider"></div>
          </div>
          <div v-if="userId">
            <a @click="logOut" class="dropdown-item">logout</a>
          </div>
          <div v-else>
            <a @click="logOut" class="dropdown-item">Register</a>
          </div>
        </div>
      </div>
      <h1 class="header text-left">Welcome to Keepr</h1>
    </nav>
    <div class="row"></div>
    <span class="d-flex flex-row justify-content-center mb-5">
      <button
        @click="notLoggedIn"
        v-if="userId"
        type="button"
        class="inline btn btn-outline-info createKeep mr-1"
        data-toggle="modal"
        data-target="#createKeepModal"
      >Create a Keep</button>
      <createKeep></createKeep>
      <button
        @click="notLoggedIn"
        v-if="userId"
        type="button"
        class="inline btn btn-outline-info createKeep ml-1"
        data-toggle="modal"
        data-target="#createVaultModal"
      >Create a Vault</button>
    </span>
    <createKeep></createKeep>
    <createVault></createVault>
    <div class="row">
      <div class="card-columns">
        <keeps class="ml-2 mt-2"></keeps>
      </div>
    </div>
  </div>
</template>

<script>
import keeps from "@/components/keeps.vue";
import createKeep from "@/components/createKeep.vue";
import createVault from "@/components/createVault.vue";

export default {
  name: "home",
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
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
    notLoggedIn() {
      if (!this.$store.state.user.id) {
        //put in a sweet alert with an option to go to login or register page
        this.$router.push({ name: "login" });
      } else {
        return;
      }
    },
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
.dropdown-item {
  cursor: pointer;
}
.dropdown {
  cursor: pointer;
}
.inline {
  display: inline-block;
}
.navbar {
  background-color: #738598;
}
.fa-bars {
  color: whitesmoke;
}
.header {
  color: whitesmoke;
}
</style>
