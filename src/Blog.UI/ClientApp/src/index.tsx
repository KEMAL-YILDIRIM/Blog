import { ConnectedRouter } from 'connected-react-router';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import store, { history } from './redux/store/store';
import registerServiceWorker from './registerServiceWorker';

const render = () => {
    const App = require('./app/App').default;

    ReactDOM.render(
        <Provider store={store}>
            <ConnectedRouter history={history}>
                <App />
            </ConnectedRouter>
        </Provider>,
        document.getElementById('root'));
}

render()


if (process.env.NODE_ENV === 'development' && module.hot) {
    module.hot.accept('./app/App', render)
}

registerServiceWorker();