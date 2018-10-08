<template>
  <div class="home">
    <h1>Keepr</h1>

<div>
<button>Create New Vault </button>
     <form class="form-inline" @submit.prevent="searchByArtist"  >
        <!--DO NOT MODIFY THE ID OR ONCLICK ATTRIBUTES IN THIS FORM-->
        <div class="form-group">
            <input type="text" class="form-control" placeholder="Name"/>
            
           </div>

   <div v-for="vault in allVaults" :key="vault._id">
    <div>

    <div style="color: blue">
    <h2>{{vault.name}}</h2>
    <h2>{{vault.description}}</h2>

   </div>
    </div>
    </div>

  </form>




           </div>
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
    // this.$store.dispatch("getAllKeeps");

    // this gets all vaults
    this.$store.dispatch("getAllVaults");
  },

  data() {
    return {
      keepName: ""
    };
  },

  computed: {
    allKeeps() {
      return this.$store.state.keeps;
    },
    allVaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    createVault(vault) {
      this.$store.dispatch("addVaults", vault);
    }
  }
};
</script>