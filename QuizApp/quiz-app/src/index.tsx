import * as React from 'react';
import * as ReactDOM from 'react-dom'
import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';

import registerServiceWorker from 'registerServiceWorker';
import { rootReducer } from 'state';

import 'scss/index.scss';

import App from 'app/app';

const store = createStore(
    rootReducer,
    applyMiddleware(thunk)
);

ReactDOM.render(
    <Provider store={store}>
        <App />
    </Provider>,
    document.getElementById('react-app') as HTMLElement
);

registerServiceWorker();
