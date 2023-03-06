import { combineReducers } from 'redux';
import productsReducer from '../components/productlist/productsSlice';


const rootReducer = combineReducers({
  products: productsReducer,
});

export default rootReducer;