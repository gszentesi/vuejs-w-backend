import { createRouter, createWebHistory } from 'vue-router'
import PrimeTestView from '../views/PrimeTestView.vue'
import TableView from '../views/TableView.vue'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'test',
            component: PrimeTestView
        },
        {
            path: '/table',
            name: 'table',
            component: TableView
        }
    ]
})

export default router
