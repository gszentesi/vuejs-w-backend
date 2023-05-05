import { createApp } from 'vue';
import { createPinia } from 'pinia';

import PrimeVue from 'primevue/config';
import Button from 'primevue/button';
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import InputText from 'primevue/inputtext';
import InputNumber from 'primevue/inputnumber';

import App from './App.vue';
import router from './router';

import './assets/main.css';

import PrimeTestComponent from './components/PrimeTestComponent.vue';
import CellComponent from './components/CellComponent.vue';
import DataComponent from './components/DataComponent.vue';
import DataSimpleComponent from './components/DataSimpleComponent.vue';
import ResizerComponent from './components/ResizerComponent.vue';
import ViewModelComponent from './components/ViewModelComponent.vue';
import ViewModelComplexComponent from './components/ViewModelComplexComponent.vue';

const app = createApp(App);

app.use(PrimeVue);
app.component('Button', Button);
app.component('InputText', InputText);
app.component('InputNumber', InputNumber);
app.component('DataTable', DataTable);
app.component('Column', Column);

app.component('ResizerComponent', ResizerComponent);
app.component('CellComponent', CellComponent);
app.component('DataComponent', DataComponent);
app.component('DataSimpleComponent', DataSimpleComponent);
app.component('PrimeTestComponent', PrimeTestComponent);
app.component('ViewModelComponent', ViewModelComponent);
app.component('ViewModelComplexComponent', ViewModelComplexComponent);

app.use(createPinia());
app.use(router);

app.mount('#app');
