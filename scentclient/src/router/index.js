import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../components/Home.vue'
import Templates from '../components/Templates.vue'
import Projects from '../components/Projects.vue'
import Categories from '../components/Categories.vue'
import ContextFactors from '../components/ContextFactors.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/Categories',
    name: 'Categories',
    component: Categories
  },
  {
    path: '/ContextFactors',
    name: 'ContextFactors',
    component: ContextFactors
  },
  {
    path: '/Templates',
    name: 'Templates',
    component: Templates
  },
  {
    path: '/Projects',
    name: 'Projects',
    component: Projects
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router
