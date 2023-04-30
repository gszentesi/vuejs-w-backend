import { createRouter, createWebHistory } from 'vue-router'
import PrimeTestView from '../views/PrimeTestView.vue'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'test',
            component: PrimeTestView
        }
    ]
})

export default router
