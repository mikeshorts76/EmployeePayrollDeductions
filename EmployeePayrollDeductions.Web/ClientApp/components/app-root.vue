<template>
    <div id="app" class="container body-content">
        <div class="row">
			<div class="jumbotron">
				<h1>Employee Payroll Deductions</h1>
			</div>            
            <div>
                <router-view></router-view>
            </div>
			<br>
			<br>			
			<footer>
				<p>Employee Deductions&copy; 2018</p>
			</footer>
        </div>

    </div>

</template>

<script>
import Vue from 'vue'
import CounterExample from './counter-example'
import FetchData from './fetch-data'
import HomePage from './home-page'
// import NavMenu from './nav-menu'

Vue.component('counter-example', CounterExample);
Vue.component('fetch-data', FetchData);
Vue.component('home-page', HomePage);
// Vue.component('nav-menu', NavMenu);

export default {
    data() {
        return {
        }
    }
}
</script>

<style>
</style>