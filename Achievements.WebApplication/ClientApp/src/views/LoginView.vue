<template>
  <LoginForm />
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
