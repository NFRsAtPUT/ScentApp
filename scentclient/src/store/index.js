// store/index.js

import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    currentProjectID: -1
  },
  getters: {
    getCurrentProjectId: state => {
      return state.currentProjectID
    }
  },
  mutations: {
    setCurrentProjectId (state, id) {
      state.currentProjectID = id
    }
  },
  actions: {}
})
