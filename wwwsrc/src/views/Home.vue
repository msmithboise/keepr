<template>
  <div class="home">
    <h1>Keepr</h1>

   <div v-for="keep in allKeeps" :key="keep._id">
    <div>

    <div style="color: blue">
    <h2>{{keep.name}}</h2>
    <h2>{{keep.description}}</h2>

   </div>
    </div>
    </div>

    <button>"Create Keep"</button>




  </div>
</template>

<script>
export default {
  name: "home",
  mounted() {
    //blocks users not logged in
    if (!this.$store.state.user.id) {
      this.$router.push({ name: "login" });
    }
    // gets all keeps
    this.$store.dispatch("getAllKeeps");
  },

  data() {
    return {
      keepName: ""
    };
  },

  computed: {
    allKeeps() {
      return this.$store.state.keeps;
    }
  }
};
</script>