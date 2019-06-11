import * as React from 'react';

import { BrowserRouter, Route, Switch } from 'react-router-dom';

import NavBar from 'app/navbar';
import Login from 'app/users/login/login';
import Register from 'app/users/register';
import Home from 'app/home';

export default class App extends React.Component {
    public render() {
        return (
            <BrowserRouter>
                <div>
                    <NavBar />
                    <div className="app-content-wrapper">
                        <Switch>
                            <Route
                                exact
                                path='/'
                                component={Home} />
                            <Route
                                path='/login'
                                component={Login} />
                            <Route
                                path='/register'
                                component={Register} />
                        </Switch>
                    </div>
                </div>
            </BrowserRouter>
        );
    }
}
