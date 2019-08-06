import {Navigation} from 'react-native-navigation';
import { Screens } from './navigation';

function registerScreens() {
    Object.values(Screens)
        .forEach(screen => Navigation.registerComponent(screen.name, () => screen.component));
}

export function start () {
    registerScreens();
    Navigation.events().registerAppLaunchedListener(() => {
        Navigation.setRoot({
            root: {
                stack: {
                    children: [{
                        component: {
                            name: Screens.home.name
                        }
                    }],
                    options: {
                        topBar: {
                            visible: false,
                            height: 0
                        }
                    }
                }
            }
        });
    });
}