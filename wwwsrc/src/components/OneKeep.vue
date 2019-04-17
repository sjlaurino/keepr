<template>
  <div class="OneKeep">
    <div
      class="modal fade"
      id="oneKeepModal"
      tabindex="-1"
      role="dialog"
      aria-labelledby="exampleModalLabel"
      aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">{{activeKeep.name}}</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>

          <div class="card">
            <img :src="activeKeep.img" class="card-img-top img-fluid">
            <div class="card-body">
              <p class="card-text">{{activeKeep.description}}</p>
              <span class="d-flex flex-row justify-content-between">
                <span>
                  <i class="far fa-eye clicks"></i>
                  {{keep.views}}
                </span>
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
  props: [],
  data() {
    return {};
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    }
  },
  methods: {},
  components: {}
};
</script>