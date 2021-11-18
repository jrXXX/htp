import "./App.css";
import Home from './components/Home';
import Rooms from './pages/Rooms';
import Header from "./components/Header";
import BookRoomForm from "./components/BookRoomForm";

import createRootReducer from './reducers'
import Error from './pages/Error';

import { Route, Switch } from "react-router-dom";
import { routerMiddleware } from 'connected-react-router';
import {composeWithDevTools} from 'redux-devtools-extension';

import {Provider} from 'react-redux';
import thunk from 'redux-thunk';
import {createStore, applyMiddleware} from 'redux'
import {createBrowserHistory } from 'history';

function App() {

  const history = createBrowserHistory();
  const middelwares = [thunk, routerMiddleware(history)];
  const store = createStore(
      createRootReducer(history),
      composeWithDevTools(applyMiddleware(...middelwares))
  )

  return (
    <Provider store={store}> 
      <div className="App">
        <Header />
        <Switch>
        <Route exact path="/" component={Home} />
          <Route exact path="/rooms/" component={Rooms} />
          <Route exact path="/rooms/:book" component={BookRoomForm} />
          <Route component={Error} />
        </Switch>
      </div>
    </Provider>
  );
}

export default App;
