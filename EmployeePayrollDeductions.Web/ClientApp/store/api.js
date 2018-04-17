
//resources/assets/js/vuex/utils/api.js

import Vue from 'vue'

export default {	
	getAll(url, request) {
        return $http.get(url, request)
            .then((response) => Promise.resolve(response.body.data))
            .catch((error) => Promise.reject(error));
    },
    // get(url, request) {
    //     return Vue.http.get(url, request)
    //         .then((response) => Promise.resolve(response.body.data))
    //         .catch((error) => Promise.reject(error));
    // },
    // post(url, request) {
    //     return Vue.http.post(url, request)
    //         .then((response) => Promise.resolve(response))
    //         .catch((error) => Promise.reject(error));
    // }   
}
