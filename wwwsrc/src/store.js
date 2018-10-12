import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import keeps from './models/Keep';

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "//localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "//localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})


export default new Vuex.Store({

  state: {
    user: {},
    keeps: [],
    vaults: [],
    myKeeps: [],
    vaultKeepsById: []
  },


  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, keeps) {
      state.keeps = keeps;
    },

    setVaults(state, vaults) {
      state.vaults = vaults;
    },

    createVault(state, vault) {
      state.vaults.push(vault)
    },

    createKeep(state, keeps) {
      state.keeps.push(keeps)
    },

    setVaultKeeps(state, newVaultKeep) {
      state.myKeeps.push(newVaultKeep)
    },

    getVaultKeeps(state, vaultKeeps) {
      state.vaultKeepsById = vaultKeeps

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
          router.push({ name: 'home' })
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


    // Gets all keeps on page load
    getAllKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          // console.log(res.data)
          commit('setKeeps', res.data)
        })
    },


    // Creates new keep
    addKeep({ commit, dispatch }, keep) {
      api.post('keeps', keep)
        .then(res => {
          // console.log(res)
          commit('createKeep', res.data)
        })
    },

    // Saves keep to vault

    // saveKeep({ commit, dispatch }, savedKeep) {
    //   // dispatch("saveKeepToVault", savedKeep)
    //   console.log(savedKeep)
    // },



    // Gets all user vaults on page load
    getAllVaults({ commit, dispatch }) {
      api.get('vaults')
        .then(res => {
          // console.log(res)
          commit('setVaults', res.data)
        })
    },


    // Creates new vault
    addVault({ commit, dispatch }, vault) {
      api.post('vaults', vault)
        .then(res => {
          // console.log(res)
          commit('createVault', res.data)

        })
    },

    // POST vault keeps
    saveKeepToVault({ commit, dispatch }, vaultKeep) {
      // console.log(vaultKeep)

      api.post('vaultkeeps', vaultKeep)
        // vaultkeep has {keepId : 21, vaultId: 12}
        .then(res => {
          commit('setVaultKeeps', res.data)
          // res.data has 
          // console.log(res.data)
          // res.data has object with id: , keep id, userId, vaultId
        })
    },

    // GET vault keeps

    getAllVaultKeeps({ commit, dispatch }, vaultId) {
      api.get(`vaultkeeps/${vaultId}`)
        .then(res => {
          commit('getVaultKeeps', res.data)

          // api.get(`vaultkeeps/${vaultId}`)
        })
    },

    // Delete vault
    deleteVault({ commit, dispatch }, vaultId) {
      api.delete("vaults/" + vaultId)
        .then(res => {
          dispatch("getAllVaults")

        })
    },

    // Delete Vaultkeep (removing keep from vaultkeep)
    deleteVaultKeep({ commit, dispatch }, payload) {
      api.delete(`vaultkeeps/${payload.vId}/${payload.kId}`)
        .then(res => {
          dispatch("getAllVaultKeeps", payload.vId)

        })
    }


  }
})

// api.delete('boards/' + boardId)