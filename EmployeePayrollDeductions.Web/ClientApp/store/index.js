import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

// TYPES
const SET_CURRENT_EMPLOYEE = 'SET_CURRENT_EMPLOYEE'

// STATE
const state = {	
	currentEmployee: null
}

// MUTATIONS
const mutations = {
	[SET_CURRENT_EMPLOYEE] (state, obj) {
		state.currentEmployee = obj
	}
}

// ACTIONS
const actions = ({    
	setCurrentEmployee({ commit }, obj) {
        commit(SET_CURRENT_EMPLOYEE, obj)
	}	
})

export default new Vuex.Store({
    state,
    mutations,
    actions
});
