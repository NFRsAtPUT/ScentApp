<template>
    <v-container>
        <v-row>
        <v-col>
           <v-row>
            <h1>Projects</h1>
            <v-list>
                <v-list-item-group v-model="selectedProject" color="primary">
                    <v-list-item v-for="(item, i) in projects" :key="i">
                        <v-list-item-content>
                            <v-list-item-title v-text="item.name"></v-list-item-title>
                            <v-btn icon color="pink" v-on:click="selectProject(item.id)">
                                <v-icon>mdi-check</v-icon>
                            </v-btn>
                        </v-list-item-content>
                    </v-list-item>
                </v-list-item-group>
            </v-list>
            </v-row>
            <v-row>
                <v-text-field label="New Project" v-model="newProject.name"></v-text-field>
                   <v-btn color="primary" v-on:click="createProject">Add</v-btn>
            </v-row>
        </v-col>
        </v-row>
        <v-row v-if="projectLoaded">
        <v-col>
          <h1>Templates</h1>
          <v-row>
          <v-simple-table>
              <template v-slot:default>
                <thead>
                  <tr>
                    <th>ID</th>
                    <th>Content</th>
                  </tr>
                </thead>
                <tbody>
                    <tr v-for="t in templates" :key="t.id">
                        <td>{{t.id}} </td>
                        <td>{{t.content}}</td>
                    </tr>
                </tbody>
            </template>
          </v-simple-table>
          </v-row>
          <v-row>
            <v-text-field label="New Template" v-model="newTemplate.content"></v-text-field>
            <v-btn color="primary" v-on:click="createTemplate">Add</v-btn>
          </v-row>
        </v-col>
        </v-row>
    </v-container>
</template>

<script>
import api from '@/service/apiService'
export default {
  name: 'Templates',
  data () {
    return {
      newTemplate: {
        content: ''
      },
      newProject: {
        name: ''
      },
      newRequirement: {
        content: ''
      },
      projects: [],
      selectedProject: 1,
      selectedProjectId: 0,
      templates: [],
      requirements: [],
      projectLoaded: false,
      responseSuccess: false
    }
  },

  methods: {
    selectProject: async function (projectId) {
      const data = await api.readRequirements(projectId)
      // this.selectedProjectId = projectId
      this.requirements = data
      this.projectLoaded = true
    },
    readProjects: async function () {
      const data = await api.readProjects()
      this.projects = data
    },
    readRequirements: async function () {
      const data = await api.readRequirements()
      this.requirements = data
    },
    readTemplates: async function () {
      const data = await api.readTemplates()
      this.templates = data
    },
    createProject: async function () {
      const projectRequest = {
        name: this.newProject.name
      }
      await api.createProject(projectRequest)
      this.newProject.name = ''
      this.readProjects()
      this.responseSuccess = true
    },
    createTemplate: async function () {
      const templateRequest = {
        content: this.newTemplate.name
      }
      await api.createTemplate(templateRequest)
      this.newTemplate.name = ''
      this.readTemplates()
      this.responseSuccess = true
    },
    createRequirement: async function () {
      const reqRequest = {
        content: this.newRequirement.content
      }
      await api.createRequirement(this.selectedProjectId, reqRequest)
      this.newRequirement.content = ''
      this.readTemplates()
      this.responseSuccess = true
    }
  },

  mounted () {
    this.readTemplates()
    this.readProjects()
  }
}
</script>
