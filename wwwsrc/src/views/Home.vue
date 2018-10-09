<template>
  <v-app>
    <v-content>
      <div class="home">

        <TopNav></TopNav>





        <div class="keeps page-wrapper">


           
          <div v-for="keep in keeps" :key="keep._id">

            <v-img class="white--text" height="400px" width="250px" :src="keep.imgUrl">

              <span class="headline">{{keep.name}}</span>

              <span class="align-center">{{keep.description}}</span><br>


              

              <v-btn class="heart-icon" fab dark small color="pink">
              <v-icon dark>favorite</v-icon>
              </v-btn>
 
            </v-img>

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

<style>
.page-wrapper {
  max-width: calc(98rem + 2rem);
  margin: 0 auto;
  width: 100%;
  overflow: hidden;
  text-overflow: ellipsis;
  text-align: center;
  text-transform: uppercase;
  margin-top: 3rem;
  color: rgba(#66fcf1, 0.85);
  letter-spacing: 0.3rem !important;
}

.keeps {
  display: flex;
  align-content: center;
  justify-content: space-around;
  margin-top: 5vh;
}

.heart-icon {
  margin-top: 20vh;
}
</style>