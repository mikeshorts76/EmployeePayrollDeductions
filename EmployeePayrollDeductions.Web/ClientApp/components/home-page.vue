<template>
	<div>	
		<h2>Employees</h2>
		<div>
			<!-- <a href="#">+ Add New Employee</a> -->
			<router-link v-bind:to="'new-employee'">+ Add New Employee</router-link>
		</div>
		<br>
		<table class="table table-condensed table-hover">			
			<thead>
				<tr>					
					<th>First Name</th>
					<th>Last Name</th>
					<th>Dependents Count</th>					
				</tr>
			</thead>			
			<tbody v-for="employee in employees">
				<tr>
					<td> {{ employee.firstName }}</td>
					<td>{{ employee.lastName }}</td>
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
export default {
    data() {
        return {
			employees: null
        }
	},
	methods: {
		toggleModal: function() {
			alert('toggled');
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
