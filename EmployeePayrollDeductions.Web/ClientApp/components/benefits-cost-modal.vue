<template>
	<div class="container">
		<span class="header-background">
			<h2>Employee Benefits Cost</h2>
		</span>	
		<hr>	
		<div class="header-footer">
			<span>Employee Cost</span>
			<span class="bold" v-if="employee.isDiscount">(10% Discount)</span>	
			<span> = ${{ employee.benefitCost.toFixed(2) }}</span>			
		</div>		
		<br>
		<table>
			<thead v-if="employee.dependents.length" class="header-footer">
				<tr>
					<th class="col-sm-3">Dependent</th>
					<th class="col-sm-3">Cost</th>					
				</tr>
			</thead>
			<tfoot class="header-footer">
				<tr>
					<td class="col-sm-3">Total</td>					
					<td class="col-sm-3">${{ employee.totalBenefitCost.toFixed(2) }}</td>
				</tr>
			</tfoot>
			<tbody v-for="dependent in employee.dependents" :key="dependent.dependentId">
				<tr>
					<td class="col-sm-3">
						<span>{{ dependent.firstName + ' ' + dependent.lastName }}</span>						
						<span class="bold" v-if="dependent.isDiscount">(10% Discount)</span>						
					</td>
					<td class="col-sm-3">
						<span>${{ dependent.benefitCost.toFixed(2) }}</span>						
					</td>
				</tr>
			</tbody>		
		</table>		
	</div>
</template>
<script>	
	export default {
		data() {
			return {
				salaryAfterBenefits: (this.employee.pay - this.employee.totalBenefitCost).toFixed(2)						
			}				
		},
		props: ['employee'],  		
		methods: {
			close() {
				this.$emit('close');
			},
		}		  
	};
</script>
<style>
	.header-footer {
		font-size: large;
		font-weight: bold;
	}
	.bold {
		font-weight: bold;
		color:green
	}
</style>
