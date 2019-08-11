import * as React from 'react';
import * as ReactDOM from 'react-dom'

import registerServiceWorker from 'registerServiceWorker';

import 'scss/index.scss';

import App from 'app/app';

ReactDOM.render(
    <App />,
    document.getElementById('react-app') as HTMLElement
);

registerServiceWorker();
