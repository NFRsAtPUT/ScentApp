import axios from 'axios'

const apiClient = {
  async readTemplates () {
    const response = await axios.get('template')
    return response.data
  },

  async createTemplate (requestData) {
    const response = await axios.post('/template', requestData)
    return response.data
  },

  async deleteTemplate (templateId) {
    const response = await axios.delete('/template/' + templateId)
    return response.data
  },

  async readProjects () {
    const response = await axios.get('project')
    return response.data
  },

  async createProject (requestData) {
    const response = await axios.post('/project', requestData)
    return response.data
  },

  async getProject (projectId) {
    const response = await axios.get('/project/' + projectId)
    return response.data
  },

  async deleteProject (projectId) {
    const response = await axios.delete('/project/' + projectId)
    return response.data
  },

  async readRequirements (projectId) {
    const response = await axios.get('/requirement', projectId)
    return response.data
  },

  async createRequirement (projectId, requestData) {
    const response = await axios.post('/requirement', requestData, {
      params: {
        projectId
      }
    })
    return response.data
  }
}

export default apiClient
