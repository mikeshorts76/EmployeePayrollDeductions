<template>
	<div>
		<h2>New Employee</h2>	
		<div class="form-horizontal">       
			<hr />        
			<p v-if="errors.length">
				<b>Please correct the following error(s):</b>
				<ul>
					<li class="validation-error" v-for="error in errors" :key="error.id">
						{{ error.message }}
					</li>
				</ul>
			</p>
			<div class="form-group">            
				<label></label>
				<div class="col-md-4">                
					<label>First Name</label>
					<input class="form-control" type="text" v-model="employee.firstName"/>
				</div>
			</div>

			<div class="form-group">            
				<label></label>
				<div class="col-md-4">                
					<label>Last Name</label>
					<input class="form-control" type="text" v-model="employee.lastName"/>
				</div>
			</div>

			<div class="form-group">
				<div class="col-md-6">
					<input type="submit" value="Add" v-on:click="insertEmployee" class="btn btn-default" />
				</div>
			</div>
			<div>
				<router-link v-bind:to="'/'">Back</router-link>
			</div>
    	</div>	
	</div>
</template>
<script>
import router from 'router'

export default {
    data() {
        return {
			employee: {
				firstName: null,
				lastName: null
			},
			errors: []
        }
	},
	methods: {
		insertEmployee: function() {
			if (this.isValid()) {
				try {
					this.$http.post('/api/employee', this.employee)
						.then(function(response){
							router.push('/');
						})
						.catch(function(error) {
							console.log(error);
						})
				} catch (error) {	
					console.log(error);
				}
			}			
		},
		isValid: function(e) {
			if (this.employee.firstName && this.employee.lastName) 
				return true;
			
			this.errors = [];

			if (!this.employee.firstName)
				this.errors.push({ id: 1, message: 'First Name is Required'});

			if (!this.employee.lastName)
				this.errors.push({ id: 2, message: 'Last Name is Required'});
				
			return false;
		}
	}
}
</script>
<style>
</style>
