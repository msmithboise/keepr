<template>
<v-app>
  <v-content>
  <div class="home">

<TopNav></TopNav>




   <div v-for="keep in keeps" :key="keep._id">
  
        <v-img
          class="white--text"
          height="400px"
          width="250px"
          src="https://source.unsplash.com/random">
                
          <span class="headline">{{keep.name}}</span>
          
          <span class="align-center">{{keep.description}}</span><br>
        
        
          
          <v-btn flat color="red">Keep it</v-btn>
          
         
        </v-img>
        
            
            
        
      


  



    

   

  
   
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