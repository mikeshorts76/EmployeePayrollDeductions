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
			<tbody v-for="employee in employees">
				<tr>
					<td>{{ employee.firstName }}</td>
					<td>{{ employee.lastName }}</td>
					<td>{{ employee.dependents.length }}</td>
					<td>
						<router-link v-bind:to="'new-dependent'">+ Add Dependent</router-link>
					</td>
					<td>
						<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Calculate Benefit Costs</button>
					</td>
				</tr>
			</tbody>			
		</table>
		<div class="modal fade" id="myModal" role="dialog">
			<div class="modal-dialog modal-md">
				<div class="modal-content">
					<div class="modal-header">
						<button type="button" class="close" data-dismiss="modal">&times;</button>
						<h4 class="modal-title">Modal Header</h4>
					</div>
					<div class="modal-body">
						<p>This is a small modal.</p>
					</div>
					<div class="modal-footer">
						<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
					</div>
				</div>
			</div>
		</div>
	</div>
</template>
<script>
import { mapActions, mapState } from 'vuex'

export default {
    data() {
        return {
			employees: null
        }
	},
	// computed: {
	// 	...mapState({
  	// 		employees: state => state.employees
  	// 	})
  	// },
	methods: {
		toggleModal: function() {
			alert('toggled');
		}

	},

	created() {
		// this.getEmployees();
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
