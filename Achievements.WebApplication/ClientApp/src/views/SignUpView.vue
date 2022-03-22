<template>
  <v-container class="fill-height fill-width d-flex justify-center" max-width="1024px">
  <SignUp />
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
