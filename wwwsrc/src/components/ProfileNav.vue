<template>
   <div>
   <!-- nav bar -->
    <v-toolbar light style='background-color: var(--light-color);'>
      <!-- <v-toolbar-side-icon></v-toolbar-side-icon> -->
  
      <img src="../assets/keeprlogo.png">
  
      <v-spacer></v-spacer>
  
<!-- search bar -->
 <v-text-field
        
        class="mx-5 mt-3"
        style="color: var(--dark-color);"
        flat
        label="Search"
        prepend-inner-icon="search"
        ></v-text-field>

        <router-link :to="{name: 'home', path: '/'}"><v-btn >
        Back To Home
      </v-btn></router-link>

 <!-- <v-btn icon>
        <v-icon>more_vert</v-icon>
      </v-btn> -->
    </v-toolbar>

          <v-tabs
         
          grow
    centered
    style="background-color: var(--light-color)"
    dark
    icons-and-text
  >
    <v-tabs-slider color="yellow"></v-tabs-slider>

    <v-tab href="#tab-1">
      Vaults
      <!-- <v-icon>Vaults</v-icon> -->
    </v-tab>

    <v-tab href="#tab-2">
      Keeps
      <!-- <v-icon>Keeps</v-icon> -->
    </v-tab>

  

    <v-tab-item
      v-for="i in 3"
      :id="'tab-' + i"
      :key="i"
    >
      <v-card flat>
        <v-card-text>{{ text }}</v-card-text>
      </v-card>
    </v-tab-item>
  </v-tabs>
 </div>
</template>

<script>
export default {
  name: "top-nav",
  data() {
    return {
      text: "VAULTS GO HERE!"
    };
  }
};
</script>
      }
  },
};
</script>


<style>
</style>

