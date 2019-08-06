import Register from "./src/screens/Register";
import Home from "./src/screens/Home";
import { Navigation } from "react-native-navigation";

export const Screens = {
    home: {
        name: 'com.quizapp.Home',
        component: Home
    },
    register: {
        name: 'com.quizapp.Register',
        component: Register
    }
}

export const navigate = (id, componentName) => {
    Navigation.push(id, {component: {name: componentName}});
}
