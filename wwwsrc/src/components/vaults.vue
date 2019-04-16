<template>
  <div class="vaults">
    <div class>
      <div class="card" v-for="vault in vaults" :vaultData="vault" :key="vault._id">
        <i
          @click="deleteVault(vault)"
          class="d-flex justify-content-end far fa-trash-alt trash mt-1 mr-1"
        ></i>
        <div class="card-body">
          <h5 class="card-title">{{vault.name}}</h5>
          <p class="card-text">{{vault.description}}</p>
          <div v-for="keep in vaultKeeps" :key="keep._id">
            <div v-if="!keep.private" class="card">
              <span class="d-flex flex-row justify-content-end mr-1 mt-1 mb-1 clicks">
                <i class="fas fa-expand"></i>
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
                </span>
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
  name: "vaults",
  props: ["vaultData"],
  data() {
    return {};
  },
  computed: {
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    deleteVault(vault) {
      debugger;
      this.$store.dispatch("deleteVault", vault.id);
    }
  },
  components: {}
};
</script>
<style>
.trash {
  cursor: pointer;
}
</style>
