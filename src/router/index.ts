import { createRouter, createWebHistory } from 'vue-router'
import StoreView from '../views/StoreView.vue'
import LoginView from '../views/LoginView.vue'
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'store',
      component: StoreView
    },
    {
      path: '/login&register',
      name: 'login&register',
      component: LoginView
    },
  ]
})
export default router
