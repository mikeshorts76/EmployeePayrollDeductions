<template>
	<div>			
		<h2>Employees</h2>
		<div>			
			<router-link v-bind:to="'new-employee'">+ Add New Employee</router-link>			
		</div>
		<br>
		<table class="table table-condensed table-responsive table-hover">			
			<thead>
				<tr>					
					<th class="col-sm-1"></th>
					<th class="col-sm-2">First Name</th>
					<th class="col-sm-2">Last Name</th>					
					<th class="col-sm-2">Dependents Count</th>					
					<th class="col-sm-2"></th>
					<th class="col-sm-3"></th>
				</tr>				
			</thead>			
			<tbody v-for="employee in employees" :key="employee.employeeId">				
				<tr>					
					<td v-if="employee.dependents.length" class="col-sm-1">
						<a class="btn expand" v-on:click="toggleDependents(employee)">+</a>
					</td>
					<td v-else class="col-sm-1"></td>
					<td class="col-sm-2">{{ employee.firstName }}</td>
					<td class="col-sm-2">{{ employee.lastName }}</td>
					<td class="col-sm-2">{{ employee.dependents.length }}</td>
					<td class="col-sm-2">						
						<a href="#" v-on:click="addNewDependent(employee)">+ Add Dependent</a>
					</td>
					<td class="col-sm-3">
						<button type="button" class="btn btn-primary" v-on:click="showModal(employee)">Calculate Benefit Costs</button>
					</td>
				</tr>
				<tr v-if="employee.visible" v-bind:id="employee.employeeId">
					<table class="table table-condensed table-hover table-indent">
					<thead>
						<tr>
							<th class="col-sm-4">First Name</th>
							<th class="col-sm-4">Last Name</th>
							<th class="col-sm-4">Benefit Cost</th>
						</tr>
					</thead>
					<tbody>
						<tr v-for="dependent in employee.dependents" :key="dependent.dependentId">						
							<td class="col-sm-4">
								{{ dependent.firstName }}
							</td>
							<td class="col-sm-4">
								{{ dependent.lastName }}
							</td>
							<td class="col-sm-4">
								${{ dependent.benefitCost.toFixed(2) }}
							</td>
						</tr>
					</tbody>
					</table>
				</tr>
			</tbody>			
		</table>		  		
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
		toggleDependents: function(employee) {
			employee.visible === false ? employee.visible = true : employee.visible = false;			
		},
		showModal: function(selectedEmployee) {
			this.$modal.show(BenefitsCostModal, {
				employee: selectedEmployee
		}, 
		{
			draggable: true
		},
		
		)}
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
	.expand {
		font-size: large;
		font-weight: bold;
		padding: 0px;
	}
	.table-indent {
		margin-left: 40px;
	}
</style>
