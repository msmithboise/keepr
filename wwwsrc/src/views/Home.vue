<template>
<v-app>
  <v-content>
  <div class="home">

<TopNav></TopNav>
    <h1>Keepr</h1>



   <div v-for="keep in keeps" :key="keep._id">
    

    <div style="color: blue">
    <h2>{{keep.name}}</h2>
    <h2>{{keep.description}}</h2>

   </div>
   
    </div>



           
  </div>
  </v-content>
  </v-app>
</template>

<script>
import TopNav from "@/components/TopNav.vue";

export default {
  name: "home",
  mounted() {
    //blocks users not logged in
    if (!this.$store.state.user.id) {
      this.$router.push({ name: "login" });
    }
    // gets all keeps
    this.$store.dispatch("getAllKeeps");

    // this gets all vaults
  },

  data() {
    return {
      keepName: ""
    };
  },

  // v-for is iterating computed
  computed: {
    keeps() {
      return this.$store.state.keeps;
    }
  },

  components: {
    TopNav
  },
  methods: {
    createVault(vault) {
      this.$store.dispatch("addVaults", vault);
    }
  }
};
</script>