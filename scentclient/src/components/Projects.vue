<template>
<v-container>
    <v-row style="margin-top:20px">
        <v-col>
            <h2>Project</h2>
        </v-col>
    </v-row>
    <v-row v-if="!currentProject.created">
        <v-col cols="5">
        <v-sheet>
        <v-text-field label="New Project" v-model="newProject.name" clearable counter="50" :rules="rules" ></v-text-field>
        <v-btn color="primary" v-on:click="createProject">Add</v-btn>
        </v-sheet>
        </v-col>
    </v-row>
    <v-row v-if="currentProject.created">
        <v-col cols="5">
        <v-sheet>
        <v-text-field label="Your Current Project" v-model="currentProject.name" disabled></v-text-field>
        <v-btn color="primary" v-on:click="clearCurrentProject">Change to New Project</v-btn>
        </v-sheet>
        </v-col>
    </v-row>
</v-container>
</template>
<script>
import api from '@/service/apiService'
export default {
  name: 'Projects',
  data () {
    return {
      currentProject: {
        id: -1,
        name: '',
        created: false
      },
      newProject: {
        name: ''
      },
      rules: [v => v.length <= 50 || 'Max 50 characters']
    }
  },
  methods: {
    createProject: async function () {
      const projectRequest = {
        name: this.newProject.name
      }
      const id = await api.createProject(projectRequest)
      this.currentProject.id = id
      this.currentProject.name = this.newProject.name
      this.newProject.name = ''
      this.$store.commit('setCurrentProjectId', id)
      this.responseSuccess = true
      this.currentProject.created = true
    },
    clearCurrentProject: async function () {
      this.currentProject.id = -1
      this.currentProject.name = ''
      this.$store.commit('setCurrentProjectId', -1)
      this.currentProject.created = false
    },
    initForm: async function () {
      if (this.$store.getters.getCurrentProjectId !== -1) {
        this.currentProject.id = this.$store.getters.getCurrentProjectId
        // const projectRequest = {
        //  id: this.currentProject.id
        // }
        const a = ''
        const project = await api.getProject(this.currentProject.id)
        this.currentProject.name = project.name + a
        this.responseSuccess = true
        this.currentProject.created = true
      }
    }
  },
  mounted () {
    this.initForm()
  }
}
</script>
