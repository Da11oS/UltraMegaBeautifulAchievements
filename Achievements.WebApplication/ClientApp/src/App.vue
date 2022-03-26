<template>
  <v-app style="height: 100vh; width: 100vw">
    <v-main>
      <v-scroll-x-transition>
        <router-view style="width: 100%; height: 100%;">
        <template v-slot="{ Component }">
        <component :is="Component">
        </component>
        </template>
        </router-view>
      </v-scroll-x-transition>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import axios from "axios";
import { defineComponent } from "vue";

axios.defaults.baseURL = "https://localhost:5001";
axios.defaults.headers.common.Authorization = "Bearer " + localStorage.getItem("token");

export default defineComponent({
  name: "App",

  data() {
    return {
      //
    };
  },
});
</script>
