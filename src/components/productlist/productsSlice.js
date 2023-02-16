import { createSlice } from "@reduxjs/toolkit";
import products from "../../app/data";

export const productSlice = createSlice({
    name: "products",
    initialState: {
        products: products,
    },
    reducers: {
        getCategory: (state, action) => {
            const { cat } = action.payload;
            return state.products.filter(prod => prod.category === cat);
        },
        getBrand: (state, action) => {
            const { brand } = action.payload;
            return state.products.filter(prod => prod.brand === brand);
        },
    }
});

export const { getCategory, getBrand } = productSlice.actions;
export const topRated = (state) => [...state.products.products].sort((a,b) => b.rating - a.rating);
export const selectProducts = (state) => state.products;
export default productSlice.reducer;