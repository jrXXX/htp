import {combineReducers} from 'redux'
import {connectRouter} from 'connected-react-router'

import homeStore from './Home';

const reducer = history => combineReducers({
        router: connectRouter(history),
        homeStore: homeStore
    }
)

export default reducer;
