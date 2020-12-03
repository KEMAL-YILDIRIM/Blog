import { combineReducers } from 'redux';
import { History } from 'history';
import { connectRouter } from 'connected-react-router';


const reducer = (history: History)=> combineReducers({
    router:connectRouter(history),
});

export default reducer;