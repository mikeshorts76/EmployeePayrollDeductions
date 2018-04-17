<template>
	<div>
		<h2>New Employee</h2>	
		<div class="form-horizontal">       
        <hr />        
        <div class="form-group">            
			<label></label>
            <div class="col-md-4">                
				<label>First Name</label>
				<input class="form-control" type="text"/>
            </div>
        </div>

        <div class="form-group">            
			<label></label>
            <div class="col-md-4">                
				<label>Last Name</label>
				<input class="form-control" type="text"/>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-6">
                <input type="submit" value="Add" class="btn btn-default" />
            </div>
        </div>
		<div>
			<router-link v-bind:to="'/'">Back</router-link>
		</div>
    </div>	
	</div>
</template>
<script>
</script>
<style>
</style>
