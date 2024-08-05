import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

import PrimeVue from 'primevue/config'
import Nora from '@primevue/themes/nora'
import DialogService from 'primevue/dialogservice'
import ToastService from 'primevue/toastservice'

const app = createApp(App)
app.use(PrimeVue, {
  theme: {
    preset: Nora
  }
})
app.use(router)
app.use(DialogService)
app.use(ToastService)
app.mount('#app')
