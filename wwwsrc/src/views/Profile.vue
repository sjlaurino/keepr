<template>
  <div class="profile container">
    <div class="row">
      <h1 class="text-capitalize col-12 mt-1">{{user.username}}'s Profile</h1>
    </div>
    <span class="d-flex flex-row justify-content-center mb-2">
      <button
        v-if="user.id"
        type="button"
        class="inline btn btn-outline-info createKeep mr-1"
        data-toggle="modal"
        data-target="#createKeepModal"
      >Create a Keep</button>
      <createKeep></createKeep>
      <button
        v-if="user.id"
        type="button"
        class="inline btn btn-outline-info createKeep ml-1"
        data-toggle="modal"
        data-target="#createVaultModal"
      >Create a Vault</button>
    </span>
    <button
      @click="showPrivate = !showPrivate"
      type="button"
      class="btn btn-outline-secondary mb-5"
    >My Keeps</button>
    <div v-if="showPrivate">
      <keeps></keeps>
    </div>
    <createKeep></createKeep>
    <createVault></createVault>
    <vaults class="ml-2 mt-2" v-for="vault in vaults" :vaultData="vault" :key="vault.id"></vaults>
  </div>
</template>

<script>
import keeps from "@/components/keeps.vue";
import vaults from "@/components/vaults.vue";
import createKeep from "@/components/createKeep.vue";
import createVault from "@/components/createVault.vue";
export default {
  name: "profile",
  props: [],
  data() {
    return {
      showPrivate: false
    };
  },
  computed: {
    homePage() {
      return this.$route.name == "home";
    },
    vaults() {
      return this.$store.state.vaults;
    },
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    },
    userKeeps() {
      return this.$store.state.userKeeps;
    }
  },
  mounted() {},
  methods: {},
  components: {
    vaults,
    createKeep,
    createVault,
    keeps
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
    },
    getVaultKeeps(vaultId) {
      this.$store.dispatch("getVaultKeeps", vaultId);
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
