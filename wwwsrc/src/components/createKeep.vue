<template>
  <div class="createKeep">
    <div
      class="modal fade"
      id="createKeepModal"
      tabindex="-1"
      role="dialog"
      aria-labelledby="exampleModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Create a Keep</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <form @submit.prevent="addKeep">
            <input
              id="nameInput"
              class="col-12"
              type="text"
              placeholder="Keep Name"
              v-model="newKeep.name"
              maxlength="25"
              required
            >
            <input
              class="col-12"
              type="text"
              placeholder="Keep Description"
              v-model="newKeep.description"
              maxlength="100"
              required
            >

            <input
              class="col-12"
              type="text"
              placeholder="Image Url"
              v-model="newKeep.img"
              required
            >
            <div class="form-check">
              <input
                class="form-check-input"
                type="checkbox"
                v-model="newKeep.private"
                value
                id="defaultCheck1"
              >
              <span>
                <label class="form-check-label" for="defaultCheck1">Make Keep Private</label>
              </span>
            </div>
            <button
              type="submit"
              class="btn btn-outline-info mt-1 ml-2 mb-3"
              data-dismiss="modal"
              @click="addKeep()"
            >Create Keep</button>
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
  name: "createKeep",
  props: [],
  data() {
    return {
      newKeep: {
        Name: "",
        Description: "",
        Img: "",
        Private: false
      }
    };
  },
  computed: {},
  methods: {
    addKeep() {
      debugger;
      this.$store.dispatch("addKeep", this.newKeep);
    }
  },
  components: {}
};
</script>