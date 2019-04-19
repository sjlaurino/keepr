<template>
  <div class="keep">
    <div v-if="!showUserKeeps">
      <div v-for="keep in keeps" :key="keep.id">
        <div v-if="!keep.private" class="card shadow p-3">
          <span class="d-flex flex-row justify-content-end mr-1 mt-1 mb-1 clicks">
            <!-- change this to only be accessible by user when keep is opened -->
            <i
              @click="addView(keep)"
              class="fas fa-expand"
              data-toggle="modal"
              :data-target="'#oneKeepModal'+keep.id"
            ></i>
            <oneKeep :keep="keep"></oneKeep>
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
                <span>
                  <i
                    @click="setActiveKeep(keep)"
                    href="#"
                    id="dropdownMenuButton"
                    data-toggle="dropdown"
                    aria-haspopup="true"
                    aria-expanded="false"
                    class="far fa-save clicks"
                  ></i>
                  {{keep.keeps}}
                  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                    <a v-if="vaults.length==0">No Vaults</a>
                    <div v-else v-for="vault in vaults" :key="vault._id">
                      <a @click="addVaultKeep(vault)" class="dropdown-item">{{vault.name}}</a>
                      <div class="dropdown-divider"></div>
                    </div>
                  </div>
                </span>
              </div>
            </span>
          </div>
        </div>
      </div>
    </div>

    <div v-if="showUserKeeps">
      <div class="row">
        <div v-for="keep in userKeeps" :key="keep.id" class="col-4">
          <div v-if="!keep.private" class="card shadow p-3">
            <span class="d-flex flex-row justify-content-end mr-1 mt-1 mb-1 clicks">
              <!-- change this to only be accessible by user when keep is opened -->
              <i
                @click="addView(keep)"
                class="fas fa-expand"
                data-toggle="modal"
                :data-target="'#oneKeepModal'+keep.id"
              ></i>
              <oneKeep :keep="keep"></oneKeep>
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
                  <span>
                    <i
                      @click="setActiveKeep(keep)"
                      href="#"
                      id="dropdownMenuButton"
                      data-toggle="dropdown"
                      aria-haspopup="true"
                      aria-expanded="false"
                      class="far fa-save clicks"
                    ></i>
                    {{keep.keeps}}
                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                      <div v-for="vault in vaults" :key="vault._id">
                        <a @click="addVaultKeep(vault)" class="dropdown-item">{{vault.name}}</a>
                        <div class="dropdown-divider"></div>
                      </div>
                    </div>
                  </span>
                </div>
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
  name: "keep",
  props: [],
  mounted() {
    if (this.$route.path == "/home") {
      this.showUserKeeps = false;
    } else {
      this.showUserKeeps = true;
    }
  },
  data() {
    return {
      showUserKeeps: ""
    };
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
    },
    vaultKeeps() {
      return this.$store.state.vaultKeeps;
    },
    userKeeps() {
      return this.$store.state.userKeeps;
    }
  },
  methods: {
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
    addView(keep) {
      this.setActiveKeep(keep);
      keep.views += 1;
      this.$store.dispatch("editKeep", keep);
    },
    plusKeep(keep) {
      keep.keeps += 1;
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
.clicks {
  cursor: pointer;
}
.card {
  background-color: whitesmoke;
  border-color: #1cb3c8;
}
</style>
