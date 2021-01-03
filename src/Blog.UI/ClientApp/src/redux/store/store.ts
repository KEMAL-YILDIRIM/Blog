import { configureStore } from '@reduxjs/toolkit'
import { routerMiddleware as createRouterMiddleware } from 'connected-react-router'
import { createBrowserHistory } from 'history'
import { RootAction, RootState, Services } from 'InternalTypes'
import { applyMiddleware } from 'redux'
import { createEpicMiddleware } from 'redux-observable'
// import rootEpic from './root-epic';
import services from '../../services'
import { composeEnhancers } from './root-enhancer'
import rootReducer from './root-reducer'

// browser history
export const history = createBrowserHistory()

export const epicMiddleware = createEpicMiddleware<
  RootAction,
  RootAction,
  RootState,
  Services
>({
  dependencies: services,
})

const routerMiddleware = createRouterMiddleware(history)

// configure middlewares
const middlewares = [epicMiddleware, routerMiddleware]

// compose enhancers
const enhancers = composeEnhancers(applyMiddleware(...middlewares))

// rehydrate state on app start
const initialState = {}

// create store
const store = configureStore({
  reducer: rootReducer(history),
  preloadedState: initialState,
  middleware: enhancers,
})
// epicMiddleware.run(rootEpic);

if (process.env.NODE_ENV === 'development' && module.hot) {
  module.hot.accept('./root-reducer', () => {
    const newRootReducer = require('./root-reducer').default
    store.replaceReducer(newRootReducer)
  })
}

// export store singleton instance
export default store
export type AppDispatch = typeof store.dispatch
