<template>
  <v-app>
    <v-content>
      <div class="home">

        <TopNav></TopNav>



        <!-- Modal for creating a keep -->
        <v-layout row>
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





            <!-- save keep dialog, from clicking on heart icon here.  Saves keep into vault. -->
       <v-layout row justify-center>
    <v-dialog v-model="heartDialogVal" scrollable max-width="300px">
      
      <v-card>
        <v-card-title>Select Vault</v-card-title>
        <v-divider></v-divider>
        <v-card-text style="height: 300px;">


          
           <v-radio-group v-model="vaultId" column>
            <v-radio v-for="vault in vaults" :key="vault._id" :label="vault.name" :value="vault.id"></v-radio>
          </v-radio-group>

            
            
        </v-card-text>
        <v-divider></v-divider>
        <v-card-actions>
          <v-btn color="blue darken-1" flat @click.native="heartDialogVal = false">Close</v-btn>
          <v-btn @click="saveKeep()" color="blue darken-1" flat @click.native="heartDialogVal = false">Save</v-btn>

          
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-layout>
         






        <!-- this is where the heart icon will be calling the dialog above. -->

        <div class="page-wrapper">

          <div class="keeps">
            <div v-for="keep in keeps" :key="keep._id">
              <v-img :src="keep.imgUrl" height="200px" width="400px">
                  <!-- because v-for is here we can pass any data we want by declaring it a variable.. keep.id = keepId, in this case we are passing it into our data() so method can take it in. -->
                <v-btn @click="heartDialogVal = true; keepId = keep.id" value=true class="heart-icon" fab dark small color="pink">
                  <v-icon dark>favorite</v-icon>
                </v-btn>

              </v-img>

              <span style="color: #3b3b3b" class="headline">{{keep.name}}</span>
              <v-divider light></v-divider>
              <span style="color: #3b3b3b" class="align-center sub-text">{{keep.description}}</span><br>
            </div>
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
    this.$store.dispatch("getAllVaults");

    // this gets all vaults
  },

  data() {
    return {
      keepName: "",
      dialog: false,
      dialogSave: false,
      vaultId: "",
      keepId: "", // here is where the data was passed..
      name: "",
      description: "",
      imgUrl: "",
      heartDialogVal: false
    };
  },

  // v-for is iterating computed
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },

  components: {
    TopNav
  },
  methods: {
    createKeep() {
      let keep = {
        name: this.name,
        description: this.description,
        imgUrl: this.imgUrl
      };

      this.$store.dispatch("addKeep", keep);
    },

    // we had originally declared keep id as an empty string, but we are filling it with our new data, same with vaultId.
    saveKeep() {
      let vaultKeep = {
        keepId: this.keepId,
        vaultId: this.vaultId
      };
      this.$store.dispatch("saveKeepToVault", vaultKeep);
      // console.log(vaultKeep);

      // console.log("keepId: ", this.keepId, "vaultId: ", this.vaultId);

      // combined new found data into a single object to pass to action in store
    }
  }
};
</script>

<style>
/* .page-wrapper {
  display: flex;
  flex-direction: row;
  justify-content: center;
  margin-top: 3rem;
  width: 100%;
  height: auto;
  letter-spacing: 0.3rem;
  text-align: center;
  text-transform: uppercase;

  /* justify-content: space-evenly; */
/* max-width: calc(200rem + 2rem); */
/* margin: 0 auto; */
/* overflow: hidden;
  text-overflow: ellipsis; */

/* !important */
/* /* }  */

.keeps {
  display: flex;
  justify-content: center;
  flex-flow: row wrap;
  align-content: space-between;
}

.heart-icon {
  display: flex;
}
</style>