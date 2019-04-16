<template>
  <div class="profile container">
    <div class="row">
      <div class="col-12">
        <div class="dropdown col-1 line ml-1 mt-1">
          <i
            class="fas fa-bars d-flex"
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
        <h1>My Vaults</h1>
      </div>
    </div>
    <span class="d-flex flex-row justify-content-center mb-5">
      <button
        v-if="userId"
        type="button"
        class="inline btn btn-outline-info createKeep mr-1"
        data-toggle="modal"
        data-target="#createKeepModal"
      >Create a Keep</button>
      <createKeep></createKeep>
      <button
        v-if="userId"
        type="button"
        class="inline btn btn-outline-info createKeep ml-1"
        data-toggle="modal"
        data-target="#createVaultModal"
      >Create a Vault</button>
    </span>
    <createKeep></createKeep>
    <createVault></createVault>
    <vaults class="ml-2 mt-2" v-for="vault in vaults" :vaultData="vault" :key="vault._id"></vaults>
  </div>
</template>

<script>
import vaults from "@/components/vaults.vue";
import createKeep from "@/components/createKeep.vue";
import createVault from "@/components/createVault.vue";
export default {
  name: "profile",
  props: [],
  data() {
    return {};
  },
  computed: {
    homePage() {
      return this.$route.name == "home";
    },
    vaults() {
      return this.$store.state.vaults;
    },
    userId() {
      return this.$store.state.user.id;
    }
  },
  mounted() {
    //blocks users not logged in
    if (!this.$store.state.user.id) {
      this.$router.push({ name: "login" });
    } else {
      this.$store.dispatch("getKeeps");
      this.$store.dispatch("getVaults", this.$store.state.user.id);
    }
  },
  methods: {},
  components: {
    vaults,
    createKeep,
    createVault
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
  }
};
</script>
<style>
.dropdown-item {
  cursor: pointer;
}
.dropdown {
  cursor: pointer;
}
</style>
