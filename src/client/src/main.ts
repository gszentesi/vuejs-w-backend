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
import Cell from './components/Cell.vue';
import Data from './components/Data.vue';
import DataSimple from './components/DataSimple.vue';
import Resizer from './components/Resizer.vue';
import ViewModel from './components/ViewModel.vue';
import ViewModelComplex from './components/ViewModelComplex.vue';

const app = createApp(App);

app.use(PrimeVue);
app.component('Button', Button);
app.component('InputText', InputText);
app.component('InputNumber', InputNumber);
app.component('DataTable', DataTable);
app.component('Column', Column);

app.component('Resizer', Resizer);
app.component('Cell', Cell);
app.component('Data', Data);
app.component('DataSimple', DataSimple);
app.component('PrimeTestComponent', PrimeTestComponent);
app.component('ViewModel', ViewModel);
app.component('ViewModelComplex', ViewModelComplex);

app.use(createPinia());
app.use(router);

app.mount('#app');
