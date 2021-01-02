import { connectRouter } from 'connected-react-router';
import { History } from 'history';
import { combineReducers } from 'redux';
import postReducer from '../../components/Post/postSlice';


const rootReducer = (history: History) => combineReducers({
    router: connectRouter(history),
    post: postReducer
});


export default rootReducer;