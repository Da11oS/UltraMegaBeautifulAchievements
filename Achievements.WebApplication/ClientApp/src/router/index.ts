import Vue from 'vue';
import VueRouter, { RouteConfig } from 'vue-router';
import LoginView from '@/views/LoginView.vue';
import SignUpView from '@/views/SignUpView.vue';
import AdminView from '@/views/AdminView.vue';
import UserView from '@/views/UserView.vue';

Vue.use(VueRouter);

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Login',
    component: LoginView
  },
  {
    path: '/sign-up',
    name: 'sign-up',
    component: SignUpView
  },
  {
    path: '/achichevements',
    name: 'achichevements',
    component: SignUpView,
    children: [
      // {
      //   path: "/create",
      //   name: "editAchievements",
      //   component: SignUpView,
      // },
    ]
  },
  {
    path: '/admin',
    name: 'admin-page',
    component: AdminView
  },
  {
    path: '/userAchievements/:userId',
    name: 'user-page',
    component: UserView,
    props: true
  }
];

const router = new VueRouter({
  routes
});

export default router;
