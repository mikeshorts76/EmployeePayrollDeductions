import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

// TYPES
const MAIN_SET_COUNTER = 'MAIN_SET_COUNTER';
const EMPLOYEES = 'EMPLOYEES';

// STATE
const state = {
	counter: 0,
	employees: null
}

// MUTATIONS
const mutations = {
    [MAIN_SET_COUNTER](state, obj) {
        state.counter = obj.counter
	},
	
	// [SET_EMPLOYEES] (state, employees) {
	// 	state.employees = employees;
	// },
}

// ACTIONS
const actions = ({
    setCounter({ commit }, obj) {
        commit(MAIN_SET_COUNTER, obj)
	},
	getEmployees ({ commit }) {
		axios
			.get('/api/employee')
			.then(r => r.data)
		  	.then(employees => {
				commit('SET_EMPLOYEES', employees)
		  })
	  },
})

export default new Vuex.Store({
    state,
    mutations,
    actions
});
