import { configureStore, getDefaultMiddleware } from '@reduxjs/toolkit'
import { routerMiddleware as createRouterMiddleware } from 'connected-react-router'
import { createBrowserHistory } from 'history'
import rootReducer from './root-reducer'

// browser history
export const history = createBrowserHistory()

const routerMiddleware = createRouterMiddleware(history)

// configure middlewares
const middlewares = [...getDefaultMiddleware(), routerMiddleware]

// rehydrate state on app start
const initialState = {}

// create store
const store = configureStore({
  reducer: rootReducer(history),
  preloadedState: initialState,
  middleware: middlewares,
})

if (process.env.NODE_ENV === 'development' && module.hot) {
  module.hot.accept('./root-reducer', () => {
    const newRootReducer = require('./root-reducer').default
    store.replaceReducer(newRootReducer)
  })
}

// export store singleton instance
export default store
export type AppDispatch = typeof store.dispatch
