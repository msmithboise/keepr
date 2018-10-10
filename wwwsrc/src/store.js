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
    myKeeps: []

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
    addedVault(state, vault) {
      state.vaults.push(vault)
    },

    createKeep(state, keeps) {
      state.keeps.push(keeps)
    },

    saveToMyKeeps(state, savedKeep) {
      state.myKeeps.push(savedKeep)
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

    getAllKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          // console.log(res.data)
          commit('setKeeps', res.data)
        })
    },

    getVaults({ commit, dispatch }) {
      api.get('vaults')
        .then(res => {

          commit('setVaults', res.data)
        })
    },

    addVaults({ commit, dispatch }, vault) {
      let addedVault = {
        name: vault.name,
        description: vault.description,

      }

      api.post('/', addedVault) // this is where you're sending your board.
        .then(res => {
          commit('addToVault', res.data)
        })

    },

    addKeep({ commit, dispatch }, keep) {


      api.post('keeps', keep)
        .then(res => {
          // console.log(res)
          commit('createKeep', res.data)


        })

    },


    saveKeepToVault({ commit, dispatch }, keep) {
      api.post('', keep)
    },


    saveKeep({ commit, dispatch }, savedKeep) {
      dispatch("saveKeepToVault", savedKeep)
      console.log(savedKeep)
    }
  }
})
