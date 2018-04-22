import Vue from 'vue'
import axios from 'axios'
import router from './router'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import VModal from 'vue-js-modal'
import Toasted from 'vue-toasted'

Vue.prototype.$http = axios;

Vue.use(VModal, { dialog: true, dynamic: true })
Vue.use(Toasted)

sync(store, router)

const app = new Vue({
    store,
    router,
    ...App
})

export {
    app,
    router,
    store
}