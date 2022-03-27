<template>
  <v-container class="d-flex justify-center align-center"
               max-width="1024px">
  <LoginForm />
  </v-container>
</template>

<script lang="ts">
import LoginForm from '@/components/LoginForm.vue';
import { defineComponent } from '@vue/composition-api';

export default defineComponent({
  name: 'LoginView',
  components: {
    LoginForm
  }
});
</script>
