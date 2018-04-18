
<template>
	<div>
		<h2>New Dependent</h2>	
		<div class="form-horizontal">       
        <hr />        
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

export default {
    data() {
        return {
			dependent: {
				firstName: null,
				lastName: null
			},
			isFirstDependent: true
        }
	},
	methods: {
		insertDependent: function() {
			this.isFirstDependent = false;
			
			// try {
			// 		this.$http.post('/api/dependent', this.dependent)
			// 			.then(function(response){
			// 				router.push('/');
			// 			})
			// 			.catch(function(error) {
			// 				console.log(error);
			// 			})
			// } catch (error) {	
			// 	console.log(error);
			// }
		}
	}
}
</script>
<style>
</style>
