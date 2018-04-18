import HomePage from 'components/home-page';
import NewEmployee from 'components/new-employee';
import NewDependent from 'components/new-dependent';

export const routes = [
    { path: '/', component: HomePage, display: 'Home', style: 'glyphicon glyphicon-home' },    
	{ path: '/new-employee', component: NewEmployee, display: 'New Employee', style: 'glyphicon glyphicon-th-list' },
	{ path: '/new-dependent', component: NewDependent, display: 'New Dependent', style: 'glyphicon glyphicon-th-list' }
]