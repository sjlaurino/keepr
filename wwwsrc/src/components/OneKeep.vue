<template>
  <div class="OneKeep">
    <div
      class="modal fade"
      :id="'oneKeepModal'+keep.id"
      tabindex="-1"
      role="dialog"
      aria-labelledby="exampleModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header d-flex justify-content-between">
            <i
              v-if="user.id == activeKeep.userId"
              @click="deleteKeep(activeKeep)"
              class="far fa-trash-alt trash mt-1 mr-1"
              data-dismiss="modal"
              aria-label="Close"
            ></i>
            <h5>{{activeKeep.name}}</h5>
            <button type="button" class="close ml-0" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>

          <div class="card">
            <img :src="activeKeep.img" class="card-img-top img img-fluid">
            <div class="card-body">
              <p class="card-text">{{activeKeep.description}}</p>
              <span class="d-flex flex-row justify-content-between">
                <span>
                  <i class="far fa-eye clicks"></i>
                  {{activeKeep.views}}
                </span>
                <div class="dropdown line">
                  <i
                    v-if="user.id"
                    @click="setActiveKeep(keep)"
                    href="#"
                    id="dropdownMenuButton"
                    data-toggle="dropdown"
                    aria-haspopup="true"
                    aria-expanded="false"
                    class="far fa-save clicks"
                  ></i>
                  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                    <a v-if="vaults.length==0">No Vaults</a>
                    <div v-else v-for="vault in vaults" :key="vault._id">
                      <a @click="addVaultKeep(vault)" class="dropdown-item">{{vault.name}}</a>
                      <div class="dropdown-divider"></div>
                    </div>
                  </div>
                </div>
              </span>
            </div>
          </div>

          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "OneKeep",
  props: ["vaultId", "keep"],
  data() {
    return {};
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    user() {
      return this.$store.state.user;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    deleteKeep(activeKeep) {
      if (!this.vaultId) {
        this.$store.dispatch("deleteKeep", activeKeep);
      } else if (this.vaultId) {
        let keepId = activeKeep.id;
        let vaultId = this.vaultId;
        this.deleteKeepFromVault({ keepId: keepId, vaultId: vaultId });
      } else {
        console.log("cannot delete");
      }
    },
    addVaultKeep(vault) {
      this.vaultKeeps[vault.id].find(k => {
        let duplicate = k.id == this.activeKeep.id;
        if (duplicate) {
          alert("You already have that keep in your vault!");
        }
      });
      this.$store.dispatch("addVaultKeep", {
        vaultId: vault.id,
        keepId: this.activeKeep.id,
        userId: this.$store.state.user.id
      });
      this.plusKeep(this.activeKeep);
    },
    setActiveKeep(keep) {
      this.$store.dispatch("setActiveKeep", keep);
    },
    deleteKeepFromVault(data) {
      this.$store.dispatch("deleteKeepFromVault", data);
    },
    plusKeep(keep) {
      keep.keeps += 1;
      this.$store.dispatch("editKeep", keep);
    }
  },
  components: {}
};
</script>
<style>
.img {
  max-height: 500px;
}
</style>