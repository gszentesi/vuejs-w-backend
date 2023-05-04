import { createRouter, createWebHistory } from 'vue-router';
import PrimeTestView from '@/views/PrimeTestView.vue';
import TableView from '@/views/TableView.vue';
import GridViewVue from '@/views/GridView.vue';
import TwoWayTestVue from '@/views/TwoWayTest.vue';
import TwoWayTestTestWSimpleFields from '@/views/TwoWayTestWSimpleFields.vue';

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
        },
        {
            path: '/other',
            name: 'other',
            component: GridViewVue
        },
        {
            path: '/twoway',
            name: 'twoway',
            component: TwoWayTestVue
        },
        {
            path: '/twowaysimple',
            name: 'twowaysimple',
            component: TwoWayTestTestWSimpleFields
        }
    ]
});

export default router;
