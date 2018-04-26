<template>
	<div>
		<h2>New Dependent</h2>	
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
				<input class="form-control" type="text" v-model="dependent.firstName"/>
            </div>
        </div>

        <div class="form-group">            
			<label></label>
            <div class="col-md-4">                
				<label>Last Name</label>
				<input class="form-control" type="text" v-model="dependent.lastName"/>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-6">
                <input type="submit" v-if="isFirstDependent" value="Add" v-on:click="insertDependent" class="btn btn-default" />
				<input type="submit" v-if="!isFirstDependent" value="+ Add Another" v-on:click="insertDependent" class="btn btn-default" />
            </div>
        </div>
		<div>
			<router-link v-bind:to="'/'">Back to Employee List</router-link>
		</div>
    </div>	
	</div>
</template>
<script>
import router from 'router'
import { mapActions, mapState } from 'vuex'
import 'vue-toast/dist/vue-toast.min.css'
import VueToast from 'vue-toast'

export default {
    data() {
        return {				
			dependent: {	
				employeeId: null,			
				firstName: null,
				lastName: null
			},
			isFirstDependent: true,
			errors: []
        }
	},
	computed: {
  		...mapState({
  			employee: state => state.currentEmployee
  		})
  	},
	methods: {
		insertDependent: function() {							
			var self = this

			if (this.isValid()) {
				this.isFirstDependent = false
				this.errors = []

				try {
					this.dependent.employeeId = this.employee.currentEmployee.employeeId
					
					this.$http.post('/api/dependent', this.dependent)						
						.then(function(response){												
							self.showToast('Dependent added successfully', 'success')							
						})						
				} catch (error) {	
					self.showToast(error, 'error')
				}
			}			
		},		
		showToast: function(message, type) {
			this.$toasted.show(message, {
				position: 'bottom-center',
				type: type,
				duration: 5000,
				theme: 'outline'				
			})		
		},
		isValid: function(e) {
			if (this.dependent.firstName && this.dependent.lastName) 
				return true
			
			this.errors = []

			if (!this.dependent.firstName)
				this.errors.push({ id: 1, message: 'First Name is Required' })

			if (!this.dependent.lastName)
				this.errors.push({ id: 2, message: 'Last Name is Required' })
				
			return false
		}
	}
}
</script>
<style>
</style>
