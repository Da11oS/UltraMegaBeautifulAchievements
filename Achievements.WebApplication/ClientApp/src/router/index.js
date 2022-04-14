import Vue from 'vue';
import VueRouter from 'vue-router';
import LoginView from '@/views/LoginView.vue';
import SignUpView from '@/views/SignUpView.vue';
import AdminView from '@/views/AdminView.vue';
Vue.use(VueRouter);
const routes = [
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
        component: AdminView,
        children: [
        // {
        //   path: "/achievement-groups",
        //   name: "achievement-groups",
        //   component: SignUpView,
        // },
        // {
        //   path: "/achievement-types",
        //   name: "achievement-types",
        //   component: SignUpView,
        // },
        // {
        //   path: "/achievement-resolve",
        //   name: "achievement-resolve",
        //   component: SignUpView,
        // },
        ]
    }
];
const router = new VueRouter({
    routes
});
export default router;
//# sourceMappingURL=index.js.map