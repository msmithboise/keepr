<template>
  <div class="home">
    <h1>Welcome Home</h1>

    <!-- <div v-for="keep in keeps" :key="keep">
    </div> -->

    <h2>{{keeps[0]}}</h2>
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
    keeps() {
      return this.$store.state.keeps;
    }
  }
};
</script>