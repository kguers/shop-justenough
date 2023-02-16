import React from "react";
import { Col, Row } from "react-bootstrap";
import { useSelector } from "react-redux";
import { Product } from "../product/product";
import { topRated } from "./productsSlice";
export const ProductList = ({productAmount}) => {
    const products = useSelector(topRated);

    return (
        <Row>
           {products.slice(0, productAmount).map((prod, i)=> {
                return <Product key={`top-${i+1}`} prod={prod}/>
           })}
        </Row>
    );
}