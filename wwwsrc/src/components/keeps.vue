<template>
  <div class="keep">
    <div v-for="keep in keeps" :key="keep._id">
      <div v-if="!keep.private" class="card">
        <img :src="keep.img" class="card-img-top img-fluid">
        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <p class="card-text">{{keep.description}}</p>
          <a href="#" class="mt-1 btn btn-primary">View</a>
          <div class="dropdown col-1 line ml-1 mt-1">
            <a
              href="#"
              class="mt-1 btn"
              id="dropdownMenuButton"
              data-toggle="dropdown"
              aria-haspopup="true"
              aria-expanded="false"
            >Add to Vault</a>
            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <div v-for="vault in vaults" :key="vault._id">
                <a @click="addVaultKeep" class="dropdown-item">{{vault.name}}</a>
                <div class="dropdown-divider"></div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "keep",
  props: [],
  data() {
    return {};
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    addVaultKeep() {
      console.log("Getting here?");
    }
  },
  components: {}
};
</script>
<style>
</style>
