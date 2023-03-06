import React, {useEffect} from "react";
import { Row } from "react-bootstrap";
import { useSelector, useDispatch } from "react-redux";
import { Product } from "../product/product";
import { selectError, selectLoading, loadProducts} from "./productsSlice";
export const ProductList = ({itemsPerPage, filter}) => {
    const dispatch = useDispatch();
    const loading = useSelector(selectLoading);
    const error = useSelector(selectError);
    
    const products = useSelector(state => {
        if(filter === 'topRated'){
            return [...state.products.products].sort((a, b) => b.rating - a.rating);
        } else {
            return state.products;
        }
    })

    useEffect(() => {
        dispatch(loadProducts());
    }, [dispatch]);

    if (loading) {
        return <div>Loading...</div>;
      }
    
    if (error) {
        return <div>{ `Error: ${error}`}</div>;
    }
    return (
        <Row>
           {products.slice(0, itemsPerPage).map((prod, i)=> {
                return <Product key={`top-${i+1}`} prod={prod}/>
           })}
        </Row>
    );
}