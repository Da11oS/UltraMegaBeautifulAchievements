<template>
  <v-container class="pt-10">
    <v-row  class="d-flex justify-center align-center">
    <SignUp/>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import LoginForm from "@/components/LoginForm.vue";
import SignUp from "@/components/SignUp.vue";
import { defineComponent } from "vue"; // @ is an alias to /src

export default defineComponent({
  name: "SignUpView",
  components: {
    SignUp,
  },
});
</script>
