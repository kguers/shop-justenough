import React from "react";
import './home.css';
import { Hero } from "../hero/hero";
import { Container } from "react-bootstrap";
import { ProductList } from "../productlist/productlist";

export const Home = () => {
    return (
        <Container className="home accountForNav">
            <Hero />
            <h3 className="pop-title">Most Popular</h3>
            <ProductList productAmount={4} filter={"topRated"}/>
        </Container>
    );
}