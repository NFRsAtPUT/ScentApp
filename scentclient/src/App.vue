<template>
  <v-app id="inspire">
    <v-app-bar app color="white" flat>
      <v-container>
        <v-btn to="/">Home</v-btn>
        <v-btn to="/about">About</v-btn>
      <v-spacer></v-spacer>

      <v-responsive max-width="260"></v-responsive>
      </v-container>
    </v-app-bar>
    <v-main>
      <v-container>
        <v-row>
          <v-col rounded="g">
            <v-sheet>
              <router-view></router-view>
            </v-sheet>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
</template>

<script>

export default {
  name: 'App',
  components: {

  },

  data: () => ({})
}
</script>
