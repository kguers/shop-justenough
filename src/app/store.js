import { configureStore } from "@reduxjs/toolkit";
import productsReducer from "../components/productlist/productsSlice";

export default configureStore({
    reducer: {
        products: productsReducer,
    }
});