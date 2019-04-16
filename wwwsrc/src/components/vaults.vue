<template>
  <div class="vaults">
    <div class="card col-3">
      <i @click="deleteVault" class="d-flex justify-content-end far fa-trash-alt trash mt-1"></i>
      <div class="card-body">
        <h5 class="card-title">{{vaultData.name}}</h5>
        <p class="card-text">{{vaultData.description}}</p>
        <a href="#" class="mt-1 btn btn-primary">Open Vault</a>
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
  computed: {},
  methods: {
    deleteVault() {
      this.$store.dispatch("deleteVault", this.vaultData);
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
