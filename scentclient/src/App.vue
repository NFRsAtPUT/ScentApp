<template>
  <v-app>
    <v-navigation-drawer permanent app :width="200">
      <v-list-item>
        <v-list-item-content>
          <v-list-item-title class="title">
            <v-img :src="require('@/assets/logo.png')" width="36px">
            </v-img> SCENt
          </v-list-item-title>
          <v-list-item-subtitle class="text-wrap">
            Supporting Catalog-based Elicitation of Non-functional requirements
          </v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>

      <v-divider></v-divider>

      <v-list dense nav>
        <v-list-item
          v-for="item in items"
          :key="item.title"
          link
          @click="$router.push({ path: item.route })"
          :disabled="isDisabled(item.title)"
        >
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-main>
     <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script>
export default {
  data () {
    return {
      isProjectSelected: true,
      items: [
        { title: 'Home', icon: 'mdi-home-outline', route: '/' },
        { title: 'Projects', icon: 'mdi-view-dashboard', route: '/Projects' },
        { title: 'Context Factors', icon: 'mdi-atom', route: '/ContextFactors' },
        { title: 'Categories', icon: 'mdi-shape-outline', route: '/Categories' },
        { title: 'Templates', icon: 'mdi-puzzle-outline', route: '/Templates' },
        { title: 'About', icon: 'mdi-information-outline', route: '/About' }
      ],
      right: null
    }
  },
  methods: {
    isDisabled: function (text) {
      if (text === 'Home' || text === 'About' || text === 'Projects') {
        return false
      }
      return this.isProjectSelected
    }
  },
  mounted () {
    console.log(this.$store.getters.getCurrentProjectId)
  }
}
</script>
