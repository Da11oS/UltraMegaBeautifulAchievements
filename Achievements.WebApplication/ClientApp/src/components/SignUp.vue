<template>
  <v-card class="elevation-12" width="600">
    <v-toolbar dark color="primary">
      <v-toolbar-title>Sign up form</v-toolbar-title>
    </v-toolbar>
    <v-card-text>
      <v-form ref="form">
        <v-list>
          <v-list-item>
            <v-text-field
              label="First name"
              v-model="model.firstName"
              :rules="rules"
              hide-details="auto"
            ></v-text-field>
          </v-list-item>
          <v-list-item>
            <v-text-field
              label="Last name"
              v-model="model.lastName"
              :rules="rules"
              hide-details="auto"
            ></v-text-field>
          </v-list-item>
          <v-list-item>
            <v-text-field
              label="Patronymic"
              v-model="model.patronymic"
              :rules="rules"
              hide-details="auto"
            ></v-text-field>
          </v-list-item>
          <v-list-item>
            <v-text-field
              label="User name"
              v-model="model.userName"
              :rules="rules"
              hide-details="auto"
            ></v-text-field>
          </v-list-item>
          <v-list-item>
            <v-text-field
              label="Email"
              v-model="model.email"
              :rules="emailRules"
              hide-details="auto"
            ></v-text-field>
          </v-list-item>
          <v-list-item>
            <v-text-field
              label="Password"
              v-model="model.password"
              :rules="rules"
              hide-details="auto"
              type="password"
            ></v-text-field>
          </v-list-item>
        </v-list>
      </v-form>
    </v-card-text>
    <v-card-actions>
      <v-btn  @click="$router.back()">Back</v-btn>
      <v-spacer></v-spacer>
      <v-btn color="primary" @click="signUp">
        Sign Up
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script lang="ts">
import { Component, onMounted, computed, defineComponent, ref } from "vue";
import { FetchService, Service, User } from "@/api";
import axios from "axios";

const rules = [
  (value: string) => !!value || "Required.",
  (value: string) => (value && value.length >= 3) || "Min 3 characters",
];
export default defineComponent({
  name: "SignUp",
  methods: {
  },
  setup(root) {
    const form = ref(null);
    const model = ref<User>({
      firstName: "",
      lastName: "",
      patronymic: "",
      userName: "",
      password: "",
    } as User);
    const isValid = ref<boolean>(true);
    const emailRules = computed(() => [...rules, ...[(value: string) => {
      return String(value)
        .toLowerCase()
        .match(
          /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
        );
    }]]);
    async function signUp() {
      // const svc = new Service();
      const fsvc = new FetchService();
      try {
        // const response = await svc.post<User>("/Register", model.value);
        const response = await fsvc.post(model.value, "Users/Register");
      } catch (ex) {
        console.error(ex);
      }
    }
    function validate() {
      if (form.value) {
        console.log(typeof form.value);
      }
    }
    return {
      rules,
      emailRules,
      isValid,
      model,
      signUp,
      validate,
    };
  },
});
</script>

<style scoped>

</style>
