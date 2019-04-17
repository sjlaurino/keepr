<template>
  <div class="keep">
    <div v-for="keep in keeps" :key="keep._id">
      <div v-if="!keep.private" class="card">
        <span class="d-flex flex-row justify-content-end mr-1 mt-1 mb-1 clicks">
          <!-- change this to only be accessible by user when keep is opened -->
          <i
            @click="setActiveKeep(keep)"
            class="fas fa-expand"
            data-toggle="modal"
            data-target="#oneKeepModal"
          ></i>
          <!-- jquery this modal to get it to trigger modal from state after the active keep is set -->
        </span>
        <img :src="keep.img" class="card-img-top img-fluid">
        <div class="card-body">
          <h5 class="card-title">{{keep.name}}</h5>
          <p class="card-text">{{keep.description}}</p>
          <span class="d-flex flex-row justify-content-between">
            <span>
              <i class="far fa-eye clicks"></i>
              {{keep.views}}
            </span>
            <div class="dropdown line">
              <i
                @click="setActiveKeep(keep)"
                href="#"
                id="dropdownMenuButton"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
                class="far fa-save clicks"
              ></i>
              <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                <div v-for="vault in vaults" :key="vault._id">
                  <a @click="addVaultKeep(vault)" class="dropdown-item">{{vault.name}}</a>
                  <div class="dropdown-divider"></div>
                </div>
              </div>
            </div>
          </span>
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
    },
    activeKeep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {
    addVaultKeep(vault) {
      this.$store.dispatch("addVaultKeep", {
        vaultId: vault.id,
        keepId: this.activeKeep.id,
        userId: this.$store.state.user.id
      });
    },
    setActiveKeep(keep) {
      this.$store.dispatch("setActiveKeep", keep);
    },
    deleteKeep(keep) {
      debugger;
      this.$store.dispatch("deleteKeep", keep);
    }
  },
  components: {}
};
</script>
<style>
.clicks {
  cursor: pointer;
}
.card {
  background-color: lightgray;
}
</style>
