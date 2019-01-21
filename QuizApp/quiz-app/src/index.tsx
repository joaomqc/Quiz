import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Router, Route } from 'react-router';
import createBrowserHistory from 'history/createBrowserHistory';

import registerServiceWorker from 'registerServiceWorker';

import 'scss/index.scss';

import App from 'app/app';

let history = createBrowserHistory();

ReactDOM.render(
  <Router history={history}>
    <Route
      path={'/'}
      component={App} />
  </Router>,
  document.getElementById('react-app') as HTMLElement
);
registerServiceWorker();
