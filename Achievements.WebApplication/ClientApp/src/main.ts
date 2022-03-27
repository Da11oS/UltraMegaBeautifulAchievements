import Vue from 'vue';
import App from './App.vue';
import router from './router';
import vuetify from './plugins/vuetify';
import axios from 'axios';
import VueCompositionAPI from '@vue/composition-api';
Vue.config.productionTip = false;
axios.defaults.baseURL = 'https://localhost:5001';
axios.defaults.headers.common.Authorization = 'Bearer ' + localStorage.getItem('token');

Vue.use(VueCompositionAPI);
new Vue({
  router,
  vuetify,
  render: h => h(App)
}).$mount('#app');
