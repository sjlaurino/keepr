<template>
  <div class="vaults">
    <div class="card vault shadow p-3">
      <i
        @click="deleteVault(vaultData)"
        class="d-flex justify-content-end far fa-trash-alt trash mt-1 mr-1"
      ></i>
      <div class="card-body">
        <h5 class="card-title">{{vaultData.name}}</h5>
        <p class="card-text">{{vaultData.description}}</p>
        <hr>
        <div v-for="keep in vaultKeeps" :key="keep._id" class="make-inline col-12 col-md-3">
          <div class="card">
            <span class="d-flex flex-row justify-content-end mr-1 mt-1 mb-1 clicks">
              <i
                @click="addView(keep)"
                class="fas fa-expand"
                data-toggle="modal"
                :data-target="'#oneKeepModal'+keep.id"
              ></i>
              <oneKeep :vaultId="vaultData.id" :keep="keep"></oneKeep>
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
</template>

<script>
import oneKeep from "@/components/OneKeep.vue";
export default {
  name: "vaults",
  props: ["vaultData"],
  data() {
    return {};
  },
  computed: {
    vaultKeeps() {
      return this.$store.state.vaultKeeps[this.vaultData.id];
    },
    vaults() {
      return this.$store.state.vaults;
    },
    activeKeep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {
    deleteVault(vault) {
      this.$store.dispatch("deleteVault", vault.id);
    },
    addView(keep) {
      this.setActiveKeep(keep);
      keep.views += 1;
      this.$store.dispatch("editKeep", keep);
    },
    setActiveKeep(keep) {
      this.$store.dispatch("setActiveKeep", keep);
    }
  },
  components: { oneKeep }
};
</script>
<style>
.trash {
  cursor: pointer;
}

.make-inline {
  display: inline-block;
}
.vault {
  background-color: #dfe2e2;
}
</style>
