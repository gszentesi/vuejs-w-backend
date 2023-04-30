import { createApp } from 'vue'
import { createPinia } from 'pinia'

import PrimeVue from 'primevue/config'
import Button from 'primevue/button'
import DataTable from 'primevue/datatable'
import Column from 'primevue/column'
import InputText from 'primevue/inputtext'

import App from './App.vue'
import router from './router'

import './assets/main.css'

import PrimeTestComponentVue from './components/PrimeTestComponent.vue'

const app = createApp(App)

app.use(PrimeVue)
app.component('Button', Button)
app.component('InputText', InputText)
app.component('DataTable', DataTable)
app.component('Column', Column)

app.component('PrimeTestComponent', PrimeTestComponentVue)

app.use(createPinia())
app.use(router)

app.mount('#app')
