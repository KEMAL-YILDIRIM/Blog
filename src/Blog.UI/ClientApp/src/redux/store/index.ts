import { applyMiddleware, combineReducers, compose, createStore } from 'redux';
import thunk from 'redux-thunk';
import { connectRouter, routerMiddleware } from 'connected-react-router';
import { createBrowserHistory } from 'history';
import { createEpicMiddleware } from 'redux-observable';

import services from '../../services'
import Actions from '../actions'
import Epics from '../epics'


export const history = createBrowserHistory();
const router = routerMiddleware(history);

export const epic = createEpicMiddleware<Actions,Epics,State>({dependencies:services});