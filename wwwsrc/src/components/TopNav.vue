<template>

  <!-- nav bar -->
  <v-toolbar light style='background-color: var(--light-color);'>
    <!-- <v-toolbar-side-icon></v-toolbar-side-icon> -->

    <img src="../assets/keeprlogo.png">

    <v-spacer></v-spacer>

    <!-- search bar -->
    <v-text-field class="mx-5 mt-3" style="color: var(--dark-color);" flat label="Search" prepend-inner-icon="search"></v-text-field>

    <!-- <v-btn icon>
        <v-icon>more_vert</v-icon>
      </v-btn> -->



    <router-link :to="{name: 'profile', path: '/'}">
      <v-btn class="heart-icon icons" fab light small color="white">
        <v-icon dark>person_pin</v-icon>
      </v-btn>
    </router-link>



  </v-toolbar>


</template>

<script>
  export default {
    name: "top-nav"
  };
</script>


<style>
  .icons {
    font-size: 30px;
  }
</style>