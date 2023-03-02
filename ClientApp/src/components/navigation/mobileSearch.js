import React from "react";
import './navigation.css';
import { Form, Button, } from "react-bootstrap";

export const MobileSearch = () => {
    return (
    <Form className="d-flex d-sm-none mobileSearch">
        <Form.Control
            type="search"
            placeholder="Search for Product"
            className="me-2 bar"
            aria-label="Search"
        />
        <Button variant="primary">Search</Button>
    </Form>
    );
}