import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import { baseurl } from "../../app/data";
import axios from "axios";

const controller = "api/Product/";

export const loadProducts = createAsyncThunk('products/loadProducts',
    async () => {
        const response = await axios.get(baseurl + controller);
        let data = await response.data;
        return data; 
});

export const productSlice = createSlice({
    name: "products",
    initialState: {
        products: [],
        isLoading: false,
        hasError: false,
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
    },
    extraReducers: {
        [loadProducts.pending]: (state, action) => {
            state.isLoading = true;
            state.hasError = false;
        },
        [loadProducts.fulfilled]: (state, action) => {
            state.isLoading = false;
            state.hasError = false;
            state.products = action.payload;
        },
        [loadProducts.rejected]: (state, action) => {
            state.isLoading = false;
            state.hasError = true;
        },
    }
});

export const { getCategory, getBrand } = productSlice.actions;
export const selectLoading = (state) => state.isLoading;
export const selectError = (state) => state.hasError;
export default productSlice.reducer;