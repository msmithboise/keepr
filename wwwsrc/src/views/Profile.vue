<template>
<v-app>
  <div>

    <ProfileNav></ProfileNav>
    <div>

      <h1 class="mt-5">My Vaults</h1>
    </div>
    <!-- Modal for creating a keep -->
    <div>
      <v-layout row>
        <v-dialog v-model="dialog" persistent max-width="500px">
         
         
          <v-btn class="mt-5" fab slot="activator" color="white" light>
            <v-icon>add_circle_outline</v-icon>
          </v-btn>



          <v-card>
            <v-card-title>
              <span class="headline align-center">Create Vault</span>
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

                </v-layout>
              </v-container>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" flat @click.native="dialog = false">Cancel</v-btn>
              <v-btn @click="createVault()" color="blue darken-1" flat @click.native="dialog = false">Create</v-btn>
            </v-card-actions>
            <!-- </div> -->
          </v-card>
        </v-dialog>
      </v-layout>





      <div class="page-wrapper">

        <div class="vaults">
          <div v-for="vault in vaults" :key="vault.id">

            <div @click="keepsPage(vault)" class="vault-card">

          <v-btn @click="deleteVault(vault.id)" class="mt-5" small fab  color="white" light>
            <v-icon>delete_forever</v-icon>
          </v-btn>
              <div clas="vault-header">
                <span style="color: #3b3b3b" class="headline">{{vault.name}}</span>
              </div>
              <v-divider light></v-divider>
              <div class="vault-sub">
                <span style="color: #3b3b3b" class="align-center sub-text">{{vault.description}}</span><br>
              </div>


            </div>

          </div>
        </div>
      </div>




    </div>

  </div>






</v-app>
</template>

<script>
import ProfileNav from "@/components/ProfileNav.vue";

export default {
  name: "profile",

  mounted() {
    this.$store.dispatch("getAllVaults");
  },

  data() {
    return {
      dialog: false,
      name: "",
      description: ""
    };
  },

  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },

  methods: {
    createVault() {
      let vault = {
        name: this.name,
        description: this.description
      };

      this.$store.dispatch("addVault", vault);
    },

    deleteVault(vaultId) {
      this.$store.dispatch("deleteVault", vaultId);
      console.log(vaultId);
      // vaultId = 12
    },

    keepsPage(vault) {
      this.$router.push({
        name: "vault",
        params: {
          vaultId: vault.id
        }
      });

      // need to change this route to hit vault/id
    }
  },

  components: {
    ProfileNav
  }
};
</script>


<style>
.vault-card {
  display: flex;
  flex-flow: wrap row;
  justify-content: space-between;
  height: 15vh;
  width: 30vh;
  margin: 2vh 2vw;
  border-radius: 2%;
  box-shadow: 1px 1px 2px #e7e7e7;
  border-radius: 4px;
  z-index: 0;
}

.vault-header {
  display: flex;
  justify-content: center;
}
</style>