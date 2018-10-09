<template>
  <v-app>
    <v-content>
      <div class="home">

        <TopNav></TopNav>





        <v-layout row justify-center>
          <v-dialog v-model="dialog" persistent max-width="500px">
            <v-btn class="mt-5" fab slot="activator" color="white" light>
              <v-icon>add_circle_outline</v-icon>
            </v-btn>
            <v-card>
              <v-card-title>
                <span class="headline align-center">Create Keep</span>
              </v-card-title>
              <!-- <div v-for="keep in keeps" :key="keep._id"> -->
              <v-card-text>
                <v-container grid-list-md>
                  <v-layout wrap>



                    <v-flex xs12>
                      <v-text-field label="Name" type="text" class="form-control" v-model="name" required></v-text-field>
                    </v-flex>
                    <v-flex xs12>
                      <v-text-field label="Description" type="text" class="form-control" v-model="description" required></v-text-field>
                    </v-flex>
                    <v-flex xs12 sm6>

                      <v-text-field label="Image Link" type="text" class="form-control" v-model="imgUrl" required></v-text-field>
                    </v-flex>
                  </v-layout>
                </v-container>
              </v-card-text>


              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" flat @click.native="dialog = false">Cancel</v-btn>
                <v-btn @click="createKeep()" color="blue darken-1" flat @click.native="dialog = false">Create</v-btn>
              </v-card-actions>
              <!-- </div> -->
            </v-card>
          </v-dialog>
        </v-layout>









        <div class="keeps page-wrapper">



          <div v-for="keep in keeps" :key="keep._id">



            <v-img :src="keep.imgUrl" class="white--text" height="400px" width="250px">




              <v-btn @click="saveKeep(keep)" value=true class="heart-icon" fab dark small color="pink">
                <v-icon dark>favorite</v-icon>
              </v-btn>

            </v-img>

            <span style="color: #3b3b3b" class="headline">{{keep.name}}</span>
            <v-divider light></v-divider>
            <span style="color: #3b3b3b" class="align-center sub-text">{{keep.description}}</span><br>

            <!-- <img :src="keep.imgUrl" alt=""> -->
            <!-- <v-hover>
            </v-hover> -->

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
        keepName: "",
        dialog: false,
        name: "",
        description: "",
        imgUrl: "",
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
      },

      createKeep() {
        let keep = {
          name: this.name,
          description: this.description,
          imgUrl: this.imgUrl
        }
        debugger
        this.$store.dispatch("addKeep", keep);

      },

      saveKeep(saveKeep) {

        this.$store.dispatch("saveToKeep", saveKeep)
        debugger
      }
    }
  };
</script>

<style>
  /* .page-wrapper {
    max-width: calc(120rem + 2rem);
    margin: 0 auto;
    width: 100%;
    /* overflow: hidden; */
  /* text-overflow: ellipsis;
  text-align: center;
  text-transform: uppercase;
  margin-top: 3rem;
  color: rgba(#66fcf1, 0.85);
  letter-spacing: 0.3rem !important;
  } */

  */ .keeps {
    display: flex;
    align-content: center;
    justify-content: space-between;
    margin-top: 5vh;
  }

  .heart-icon {
    margin-top: 20vh;
  }
</style>