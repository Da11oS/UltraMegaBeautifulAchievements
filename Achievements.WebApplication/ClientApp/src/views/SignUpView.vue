<template>
  <v-container class="pt-10">
    <v-row  class="d-flex justify-center align-center">
    <SignUp/>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import SignUp from '@/components/SignUp.vue';
import { defineComponent } from '@vue/composition-api';

export default defineComponent({
  name: 'SignUpView',
  components: {
    SignUp
  }
});
</script>
