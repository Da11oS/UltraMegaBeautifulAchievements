<template>
<!--  <v-layout class="fill-height" >-->
      <v-card class="elevation-12" width="600">
        <v-toolbar dark color="primary">
          <v-toolbar-title>Login form</v-toolbar-title>
        </v-toolbar>
        <v-card-text>
          <v-form @submit.prevent="loginRequest">
            <v-text-field v-model="username"
              prepend-icon="person"
              name="username"
              label="Username"
              type="text"
            ></v-text-field>
            <v-text-field v-model="password"
              id="password"
              prepend-icon="lock"
              name="password"
              label="Password"
              type="password"
            ></v-text-field>
          </v-form>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <router-link to="/sign-up">Sign up</router-link>
          <v-spacer></v-spacer>
          <v-btn color="primary" to="/">Login</v-btn>
        </v-card-actions>
      </v-card>
<!--  </v-layout>-->
</template>

<script lang='ts'>
// https://codesandbox.io/s/0q4kvj8n0l

import { defineComponent, ref } from "vue";
import axios from "axios";

export default defineComponent({
  name: "LoginForm",
  data() {
    return {
      username: "",
      password: "",
    };
  },
  props: {
    source: String,
  },
  methods: {
    async loginRequest() {
      const response = await axios.post("Login", {
        username: this.username,
        password: this.password,
      });

      localStorage.setItem("token", response.data.token);
    },
  },
});
</script>
