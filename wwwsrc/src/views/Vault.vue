<template>
    <v-app>
        <v-content>
               <ProfileNav></ProfileNav>
            <div class="Vault">

                <div>
                    <h1 class="mt-5 mb-5">My Keeps</h1>
                </div>

                <!-- <h1>{{vaultkeep.name}}</h1> -->
                <div class="vaultkeeps">
                <div v-for="vaultkeep in vaultkeeps" :key="vaultkeep.id">
                <v-card hover>
              <v-img :src="vaultkeep.imgUrl" height="200px" width="400px">
                  <!-- because v-for is here we can pass any data we want by declaring it a variable.. keep.id = keepId, in this case we are passing it into our data() so method can take it in. -->
              </v-img>

              <span style="color: #3b3b3b" class="headline">{{vaultkeep.name}}</span>
              <v-divider light></v-divider>
              <span style="color: #3b3b3b" class="align-center sub-text">{{vaultkeep.description}}</span><br>
              </v-card>








                </div>
                </div>
                




            </div>
        </v-content>
    </v-app>



</template>


<script>
import TopNav from "@/components/TopNav.vue";
import ProfileNav from "@/components/ProfileNav.vue";

export default {
  name: "vault",
  props: ["vaultId"],

  data() {
    return {
      name: "",
      description: "",
      imgUrl: ""
    };
  },

  mounted() {
    this.$store.dispatch("getAllVaultKeeps", this.vaultId);
  },

  computed: {
    vaultkeeps() {
      return this.$store.state.vaultKeepsById;
    }
  },
  //mounted
  // fire off request to getVaultKeeps  pass it thisvaultId
  components: {
    TopNav,
    ProfileNav
  }
};
</script>

<style>
.vaultkeeps {
  display: flex;
  justify-content: center;
  flex-flow: row wrap;
  align-content: space-around;
}

.heart-icon {
  display: flex;
}
</style>
