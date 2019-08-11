import * as React from 'react';

import NavBar from 'app/navbar';

import { Route, Switch, Router, Redirect } from 'react-router-dom';
import { Provider } from 'react-redux';
import { routerMiddleware } from 'react-router-redux';
import { applyMiddleware, createStore } from 'redux';
import { rootReducer } from 'state';
import thunk from 'redux-thunk';
import { createBrowserHistory } from 'history';
import { Routes } from './routes';

const history = createBrowserHistory();

const store = createStore(
    rootReducer,
    applyMiddleware(thunk, routerMiddleware(history))
);

export default class App extends React.Component {
    public render() {
        return (
            <Provider store={store}>
                <Router history={history}>
                    <div>
                        <NavBar />
                        <div className="app-content-wrapper">
                            <Switch>
                                <Route
                                    exact
                                    path={Routes.Home.path}
                                    component={Routes.Home.component} />
                                <Route
                                    path={Routes.Login.path}
                                    component={Routes.Login.component} />
                                <Route
                                    path={Routes.Register.path}
                                    component={Routes.Register.component} />
                                <Redirect
                                    path='*'
                                    to={Routes.Home.path} />
                            </Switch>
                        </div>
                    </div>
                </Router>
            </Provider>
        );
    }
}
