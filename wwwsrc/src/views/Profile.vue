<template>
  <div class="profile">
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
        <h1>My Vaults</h1>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "profile",
  props: [],
  data() {
    return {};
  },
  computed: {
    homePage() {
      return this.$route.name == "home";
    }
  },
  methods: {},
  components: {},
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
</style>
