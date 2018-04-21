<template>
	<div>			
		<h2>Employees</h2>
		<div>			
			<router-link v-bind:to="'new-employee'">+ Add New Employee</router-link>			
		</div>
		<br>
		<table class="table table-condensed table-hover">			
			<thead>
				<tr>					
					<th class="col-sm-3">First Name</th>
					<th class="col-sm-3">Last Name</th>					
					<th class="col-sm-2">Dependents Count</th>					
					<th class="col-sm-2"></th>
					<th class="col-sm-2"></th>
				</tr>
			</thead>			
			<tbody v-for="employee in employees" :key="employee.employeeId">
				<tr>
					<td>{{ employee.firstName }}</td>
					<td>{{ employee.lastName }}</td>
					<td>{{ employee.dependents.length }}</td>
					<td>						
						<a href="#" v-on:click="addNewDependent(employee)">+ Add Dependent</a>
					</td>
					<td>
						<button type="button" class="btn btn-primary" v-on:click="showModal(employee)">Calculate Benefit Costs</button>
					</td>
				</tr>
			</tbody>			
		</table>		  
		<!-- <button type="button" class="btn btn-info btn-lg" v-on:click="showModal">Open Modal</button>    -->
		<!-- <modal name="benefits-cost">
  			<div>

			</div>
		</modal> -->
		<modals-container/>
	</div>
</template>
<script>
import { mapActions, mapState } from 'vuex';	
import router from 'router';
import BenefitsCostModal from 'components/benefits-cost-modal.vue';

export default {	
    data() {
        return {
			employees: null,	
			selectedEmployee: null				
        }
	},
	computed: {
		...mapState({
  			currentEmployee: state => state.currentEmployee
  		})
  	},
	methods: {
		...mapActions(['setCurrentEmployee']),
		toggleModal: function() {
			alert('toggled');
		},
		addNewDependent: function(employee) {
			//add current employee to state management
			this.selectedEmployee = employee;
			this.setCurrentEmployee( {currentEmployee: this.selectedEmployee })
			router.push('/new-dependent');
		},
		showModal: function(selectedEmployee) {
			this.$modal.show(BenefitsCostModal, {
				employee: selectedEmployee
				}, 
				{
					draggable: true
				},
				)
		}		
	},

	created() {		
		try {
			this.$http.get('/api/employee')
			.then(r => r.data)	
				.then(employees => {
					this.employees = employees;
			})
		} catch (error) {	
			console.log(error);
		}
	}
}
</script>

<style>
</style>
