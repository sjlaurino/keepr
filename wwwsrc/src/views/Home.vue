<template>
  <div class="home container">
    <span class="d-flex flex-row justify-content-center mb-5">
      <button
        @click="notLoggedIn"
        v-if="userId"
        type="button"
        class="inline btn btn-outline-info createKeep mt-2 mr-1"
        data-toggle="modal"
        data-target="#createKeepModal"
      >Create a Keep</button>
      <createKeep></createKeep>
      <button
        @click="notLoggedIn"
        v-if="userId"
        type="button"
        class="inline btn btn-outline-info createKeep mt-2 ml-1"
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
    if (this.userId) {
      this.$store.dispatch("getVaults");
    }
  },
  computed: {
    userId() {
      return this.$store.state.user.id;
    },
    keeps() {
      return this.$store.state.keeps;
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
