import Home from "./home/home";
import Login from "./users/login";
import Register from "./users/register";

export const Routes = {
    Home: {
        path: '/',
        component: Home
    },
    Login: {
        path: '/login',
        component: Login
    },
    Register: {
        path: '/register',
        component: Register
    }
}