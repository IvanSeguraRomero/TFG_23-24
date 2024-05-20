import { createRouter, createWebHistory } from 'vue-router'
import StoreView from '../views/StoreView.vue'
import HomeView from '../views/HomeView.vue'
import LoginView from '../views/LoginView.vue'
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'store',
      component: HomeView
    },
    {
      path: '/login&register',
      name: 'login&register',
      component: LoginView
    }
  ]
})
export default router
