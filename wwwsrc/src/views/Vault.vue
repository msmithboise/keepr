<template>
    <v-app>
        <v-content>
               <ProfileNav></ProfileNav>
            <div class="Vault">

                <div>
                    <h1 class="mt-5">My Keeps</h1>
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
  //mounted
  // fire off request to getVaultKeeps  pass it thisvaultId
  components: {
    TopNav,
    ProfileNav
  }
};
</script>