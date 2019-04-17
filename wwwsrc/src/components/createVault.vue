<template>
  <div class="createVault">
    <div
      class="modal fade"
      id="createVaultModal"
      tabindex="-1"
      role="dialog"
      aria-labelledby="exampleModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Create a Vault</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <form @submit.prevent="addVault">
            <input
              id="nameInput"
              class="col-12"
              type="text"
              placeholder="Vault Name"
              v-model="newVault.name"
              maxlength="25"
              required
            >
            <input
              class="col-12"
              type="text"
              placeholder="Vault Description"
              v-model="newVault.description"
              maxlength="100"
              required
            >

            <button
              type="submit"
              class="btn btn-outline-info mt-1 ml-2 mb-3"
              data-dismiss="modal"
              @click="addVault()"
            >Create Vault</button>
          </form>
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
  name: "createVault",
  props: [],
  data() {
    return {
      newVault: {
        name: "",
        description: ""
      }
    };
  },
  computed: {},
  methods: {
    addVault() {
      this.newVault.userId = this.$store.state.user.id;
      this.$store.dispatch("addVault", this.newVault);
      this.$router.push({ name: "profile" });
    }
  },
  components: {}
};
</script>