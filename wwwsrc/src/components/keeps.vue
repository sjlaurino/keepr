<template>
  <div class="keep row">
    <div class="card col-3">
      <img :src="keepData.img" class="card-img-top img-fluid">
      <div class="card-body">
        <h5 class="card-title">{{keepData.name}}</h5>
        <p class="card-text">{{keepData.description}}</p>
        <a href="#" class="mt-1 btn btn-primary">View</a>
        <a href="#" class="mt-1 btn btn-primary">Add to Vault</a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "keep",
  props: ["keepData"],
  data() {
    return {};
  },
  computed: {},
  methods: {},
  components: {}
};
</script>
<style>
</style>
