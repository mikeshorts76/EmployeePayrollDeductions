import HomePage from 'components/home-page'
import NewEmployee from 'components/new-employee'

export const routes = [
    { path: '/', component: HomePage, display: 'Home', style: 'glyphicon glyphicon-home' },    
	{ path: '/new-employee', component: NewEmployee, display: 'New Employee', style: 'glyphicon glyphicon-th-list' }
]