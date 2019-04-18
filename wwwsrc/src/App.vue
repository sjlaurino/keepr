<template>
  <div id="app">
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
          <div v-if="!homePage && userId">
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
    <router-view/>
  </div>
</template>
<script>
export default {
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
  computed: {
    userId() {
      return this.$store.state.user.id;
    },
    homePage() {
      return this.$route.name == "home";
    }
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}
body {
  background-color: #dfe2e2;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>