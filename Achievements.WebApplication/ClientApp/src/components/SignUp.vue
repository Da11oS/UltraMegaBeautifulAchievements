<template>
  <div>
  <v-card class="elevation-12" width="600">
    <v-toolbar dark color="primary">
      <v-toolbar-title>Sign up form</v-toolbar-title>
    </v-toolbar>
    <v-card-text>
        <v-list>
          <v-list-item>
            <v-text-field
              label="First name"
              v-model="firstName"
              :rules="rules"
              hide-details="auto"
            ></v-text-field>
          </v-list-item>
          <v-list-item>
            <v-text-field
              label="Last name"
              v-model="lastName"
              :rules="rules"
              hide-details="auto"
            ></v-text-field>
          </v-list-item>
          <v-list-item>
            <v-text-field
              label="Patronymic"
              v-model="patronymic"
              :rules="rules"
              hide-details="auto"
            ></v-text-field>
          </v-list-item>
          <v-list-item>
            <v-text-field
              label="User name"
              v-model="userName"
              :rules="rules"
              hide-details="auto"
            ></v-text-field>
          </v-list-item>
          <v-list-item>
            <v-text-field
              label="Email"
              v-model="email"
              :rules="emailRules"
              hide-details="auto"
            ></v-text-field>
          </v-list-item>
          <v-list-item>
            <v-text-field
              label="Password"
              v-model="password"
              :rules="rules"
              hide-details="auto"
              type="password"
            ></v-text-field>
          </v-list-item>
        </v-list>
    </v-card-text>
    <v-card-actions>
      <v-btn @click="$router.back()">Back</v-btn>
      <v-spacer></v-spacer>
      <v-btn color="primary" @click="signUp">
        Sign Up
      </v-btn>
    </v-card-actions>
  </v-card>
  <v-snackbar
    v-model="snackBarShow"
  >
    {{snackBarText}}
  </v-snackbar>
  </div>
</template>

<script lang="ts">
import { User } from '@/api';
import axios from 'axios';
import { computed, defineComponent, ref, watch } from '@vue/composition-api';

enum RegisterResponse{
  success = 'Пользователь создан успешно!'
}
export default defineComponent({
  name: 'SignUp',
  methods: {
  },
  setup () {
    const firstName = ref<string>('');
    const lastName = ref<string>('');
    const patronymic = ref<string>('');
    const userName = ref<string>('');
    const email = ref<string>('');
    const password = ref<string>('');
    const model = computed(() => {
      return {
        firstName: firstName.value,
        lastName: lastName.value,
        patronymic: patronymic.value,
        userName: userName.value,
        password: password.value,
        email: email.value
      };
    });
    const rules = ref<((value: string) => void)[]>([
      (value: string) => !!value || 'Required.',
      (value: string) => (value && value.length >= 3) || 'Min 3 characters'
    ]);
    const isValid = ref<boolean>(true);
    const snackBarShow = ref<boolean>(false);
    const snackBarText = ref<string>('Пользователь создан успешно!');
    const emailRules = computed(() => [...rules.value, ...[(value: string) => {
      return String(value)
        .toLowerCase()
        .match(
          /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
        );
    }]]);

    async function signUp () {
      try {
        await axios.post('Users/Register', {
          FirstName: model.value.firstName,
          LastName: model.value.lastName,
          Patronymic: model.value.patronymic,
          Username: model.value.userName,
          Email: model.value.email,
          Password: model.value.password
        });
        snackBarText.value = RegisterResponse.success;
        snackBarShow.value = true;
      } catch (ex) {
        snackBarText.value = ex as string;
        snackBarShow.value = true;
      }
    }

    watch(snackBarShow, () => {
      setTimeout(() => {
        snackBarShow.value = false;
      },
      5000);
    });
    return {
      rules,
      emailRules,
      isValid,
      model,
      signUp,
      snackBarText,
      snackBarShow,
      firstName,
      lastName,
      email,
      patronymic,
      userName,
      password
    };
  }
});
</script>
