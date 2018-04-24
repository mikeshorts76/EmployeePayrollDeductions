<template>
    <div id="app" class="container body-content">
        <div class="row">
			<div class="jumbotron text-center">
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
import HomePage from './home-page'

Vue.component('home-page', HomePage)

export default {
    data() {
        return {
        }
    }
}
</script>

<style>
</style>
