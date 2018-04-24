<template>
	<div class="padding">
		<span class="header-background">
			<h2>Annual Employee Benefits Cost</h2>
		</span>	
		<hr>	
		<div class="header-footer">
			<span>Employee Annual Salary: ${{ employee.pay.toFixed(2) }}</span>
		</div>
		<div class="header-footer">
			<span>Employee Cost</span>
			<span class="bold" v-if="employee.isDiscount">(10% Discount)</span>	
			<span>: ${{ employee.benefitCost.toFixed(2) }}</span>			
		</div>		
		<hr v-if="hasDependents">		
		<div>
			<table>
				<thead v-if="hasDependents" class="header-footer">
					<tr>
						<th class="col-sm-2">Dependent</th>
						<th class="col-sm-2 text-right">Benefit Cost</th>					
					</tr>
				</thead>
				<tfoot class="header-footer" v-if="hasDependents">
					<tr>
						<td class="col-sm-2">Total Cost (with Employee)</td>					
						<td class="col-sm-2 text-right">${{ employee.totalBenefitCost.toFixed(2) }}</td>
					</tr>					
				</tfoot>
				<tbody v-for="dependent in employee.dependents" :key="dependent.dependentId">
					<tr>
						<td class="col-sm-2">
							<span class="cell-padding">{{ dependent.firstName + ' ' + dependent.lastName }}</span>						
							<span class="bold" v-if="dependent.isDiscount">(10% Discount)</span>						
						</td>
						<td class="col-sm-2 text-right">
							<span>${{ dependent.benefitCost.toFixed(2) }}</span>						
						</td>
					</tr>
				</tbody>		
			</table>
			<hr v-if="hasDependents">					
			<div class="header-footer">
				<span>Annual Employee Salary After Benefits: ${{ salaryAfterBenefits }}</span>
			</div>
		</div>
	</div>
</template>
<script>	
	export default {
		data() {
			return {
				salaryAfterBenefits: (this.employee.pay - this.employee.totalBenefitCost).toFixed(2),
				hasDependents: this.employee.dependents.length						
			}				
		},
		props: ['employee'],  		
		methods: {
			close() {
				this.$emit('close')
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
	.cell-padding {
		padding-left: 15px;
	}
	.padding {
		padding: 15px;
	}	
</style>
