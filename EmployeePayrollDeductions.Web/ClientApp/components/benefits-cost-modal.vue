<template>
	<div class="container">
		<span class="header-background">
			<h1>Employee Benefits Cost</h1>
		</span>		
		<hr>
		<div>		
			<h3>
				Annual Salary: ${{ employee.pay.toFixed(2) }} 
			</h3>	
		</div>
		<div>		
			<h3>
				Total Benefits Cost: ${{ employee.totalBenefitCost.toFixed(2) }}
			</h3>	
		</div>
		<div>		
			<h3>
				Salary After Benefits: ${{ salaryAfterBenefits }}
			</h3>	
		</div>
		<br>
		<div class="col-md-offset-5">
			<button class="btn btn-primary" v-on:click="close">Close</button>
		</div>
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
</style>
