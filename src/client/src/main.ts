import { createApp } from 'vue';
import { createPinia } from 'pinia';

import PrimeVue from 'primevue/config';
import Button from 'primevue/button';
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import InputText from 'primevue/inputtext';
import InputNumber from 'primevue/inputnumber';
import DialogService from 'primevue/dialogservice';
import Dialog from 'primevue/dialog';
import DynamicDialog from 'primevue/dynamicdialog';

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
import InputUrlComponent from './components/InputUrlComponent.vue';
import YoutubeComponent from './components/YoutubeComponent.vue';
import TiktokComponent from './components/TiktokComponent.vue';
import InstagramCompoenent from './components/InstagramComponent.vue';
import TwitterComponent from './components/TwitterComponent.vue';
import FacebookComponent from './components/FacebookComponent.vue';

import { library } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
import { faTiktok } from '@fortawesome/free-brands-svg-icons';
import { faGripLines } from '@fortawesome/free-solid-svg-icons';

const app = createApp(App);

library.add(faTiktok);
library.add(faGripLines);
app.component('font-awesome-icon', FontAwesomeIcon);

app.use(PrimeVue);
app.component('Button', Button);
app.component('InputText', InputText);
app.component('InputNumber', InputNumber);
app.component('DataTable', DataTable);
app.component('Column', Column);
app.component('Dialog', Dialog);
app.component('DynamicDialog', DynamicDialog);

app.component('ResizerComponent', ResizerComponent);
app.component('CellComponent', CellComponent);
app.component('DataComponent', DataComponent);
app.component('DataSimpleComponent', DataSimpleComponent);
app.component('PrimeTestComponent', PrimeTestComponent);
app.component('ViewModelComponent', ViewModelComponent);
app.component('ViewModelComplexComponent', ViewModelComplexComponent);
app.component('InputUrlComponent', InputUrlComponent);
app.component('YoutubeComponent', YoutubeComponent);
app.component('TiktokComponent', TiktokComponent);
app.component('InstagramCompoenent', InstagramCompoenent);
app.component('TwitterComponent', TwitterComponent);
app.component('FacebookComponent', FacebookComponent);

app.use(createPinia());
app.use(router);
app.use(DialogService);

app.mount('#app');
