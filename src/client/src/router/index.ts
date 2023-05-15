import { createRouter, createWebHistory } from 'vue-router';
import PrimeTestView from '@/views/PrimeTestView.vue';
import TableView from '@/views/TableView.vue';
import GridView from '@/views/GridView.vue';
import TwoWayTestView from '@/views/TwoWayTestView.vue';
import TwoWayTestWSimpleFieldsView from '@/views/TwoWayTestWSimpleFieldsView.vue';
import ViewModelComplexTestView from '@/views/ViewModelComplexTestView.vue';
import ViewModelTestView from '@/views/ViewModelTestView.vue';
import EmbedView from '@/views/EmbedView.vue';
import DragAndDropViewVue from '@/views/DragAndDropView.vue';

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
            component: GridView
        },
        {
            path: '/twoway',
            name: 'twoway',
            component: TwoWayTestView
        },
        {
            path: '/twowaysimple',
            name: 'twowaysimple',
            component: TwoWayTestWSimpleFieldsView
        },
        {
            path: '/viewmodeltest',
            name: 'viewmodeltest',
            component: ViewModelTestView
        },
        {
            path: '/viewmodelcomplex',
            name: 'viewmodelcomplex',
            component: ViewModelComplexTestView
        },
        {
            path: '/embed',
            name: 'embed',
            component: EmbedView
        },
        {
            path: '/draganddrop',
            name: 'draganddrop',
            component: DragAndDropViewVue
        }
    ]
});

export default router;
