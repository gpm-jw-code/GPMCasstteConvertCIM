import {
  createRouter,
  createWebHashHistory,
  createMemoryHistory,
} from 'vue-router'
import HomeView from '../views/HomeView.vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView,
  },
  {
    path: '/secslog',
    name: 'secslog',
    component: () => import('../views/SecsMsgLog.vue'),
  },
]

const router = createRouter({
  history: createMemoryHistory(),
  routes,
})

export default router
