import Vue from 'vue'
import App from './App.vue'
import router from './router'

// axios
import axios from 'axios'
import VueAxios from 'vue-axios'
import vuetify from './plugins/vuetify'

// store vuex
import store from './store'

Vue.config.productionTip = false

// axios
Vue.use(VueAxios, axios)
axios.defaults.baseURL = 'https://localhost:5001'
new Vue({
  router,
  vuetify,
  store,
  render: h => h(App)
}).$mount('#app')
