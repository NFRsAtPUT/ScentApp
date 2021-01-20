import Vue from 'vue'
import App from './App.vue'
import router from './router'

// axios
import axios from 'axios'
import VueAxios from 'vue-axios'
import vuetify from './plugins/vuetify'

Vue.config.productionTip = false

// axios
Vue.use(VueAxios, axios)
axios.defaults.baseURL = 'https://localhost:5001'
new Vue({
  router,
  vuetify,
  render: h => h(App)
}).$mount('#app')
