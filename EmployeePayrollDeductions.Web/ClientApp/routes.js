import HomePage from 'components/home-page';
import NewEmployee from 'components/new-employee';
import NewDependent from 'components/new-dependent';

export const routes = [
    { path: '/', component: HomePage, display: 'Home' },    
	{ path: '/new-employee', component: NewEmployee, display: 'New Employee' },
	{ path: '/new-dependent', component: NewDependent, display: 'New Dependent' }
]
