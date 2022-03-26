<template>
  <v-container class="d-flex justify-center align-center"
               max-width="1024px">
  <LoginForm />
  </v-container>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import LoginForm from "@/components/LoginForm.vue"; // @ is an alias to /src

@Options({
  components: {
    LoginForm,
  },
})
export default class LoginView extends Vue {}
</script>
