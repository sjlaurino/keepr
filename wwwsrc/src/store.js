import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: [],
    userKeeps: [],
    vaultKeeps: {},
    activeKeep: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
      // state.keeps = []
    },
    setUserKeeps(state, userKeeps) {
      state.userKeeps = userKeeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
      // state.vaults = []
    },
    setActiveKeep(state, keep) {
      state.activeKeep = keep
    },
    setVaultKeeps(state, data) {
      // state.vaultKeeps = vaultKeeps
      Vue.set(state.vaultKeeps, data.vaultId, data.vaultKeeps)
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          dispatch('getKeeps')
          dispatch('getKeepsByUser')
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logOut({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'login' })
        })
    },
    getKeeps({ commit, dispatch }) {
      api.get("/keep/")
        .then(res => {
          commit("setKeeps", res.data)
        })
    },
    getKeepsByUser({ commit, dispatch }) {
      api.get("/keep/profile")
        .then(res => {
          commit("setUserKeeps", res.data)
        })
    },
    getVaultKeeps({ commit, dispatch }, vaultId) {
      api.get("/vault/" + vaultId + "/keep")
        .then(res => {
          commit("setVaultKeeps", { vaultKeeps: res.data, vaultId: vaultId })
        })
    },
    getVaults({ commit, dispatch }) {
      api.get("/vault/")
        .then(res => {
          commit("setVaults", res.data)
        }
        )
    },
    addKeep({ commit, dispatch }, keep) {
      api.post("/keep/", keep)
        .then(res => {
          dispatch("getKeeps")
          dispatch("getKeepsByUser")
        })
    },
    addVault({ commit, dispatch }, vault) {
      api.post("/vault/", vault)
        .then(res => {
          dispatch("getVaults", vault.userId)
        })
    },
    addVaultKeep({ commit, dispatch }, payload) {
      api.post("/vault/" + payload.vaultId, payload)
        .then(res => {
          dispatch("getVaultKeeps", payload.vaultId)
        })
    },
    deleteVault({ commit, dispatch }, vaultId) {
      api.delete("/vault/" + vaultId)
        .then(res => {
          dispatch("getVaults")
        })
    },
    deleteKeep({ commit, dispatch }, keep) {
      api.delete("/keep/" + keep.id)
        .then(res => {
          dispatch("getKeeps")
          dispatch("getKeepsByUser")
        })
    },
    deleteKeepFromVault({ commit, dispatch }, data) {
      debugger
      api.delete("/vault/" + data.vaultId + "/keep/" + data.keepId)
        .then(res => {
          dispatch("getVaultKeeps", data.vaultId)
        })
    },
    setActiveKeep({ commit, dispatch }, keep) {
      commit("setActiveKeep", keep)
    },
    editKeep({ commit, dispatch }, keep) {
      api.put("/keep/" + keep.id, keep)
        .then(res => {
          dispatch("getKeeps")
          dispatch("getKeepsByUser")
        })
    }
  }
})
