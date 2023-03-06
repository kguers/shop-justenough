import React, { useState } from "react";
import "./product.css"
import { Card, Col } from "react-bootstrap";

export const Product = ({ prod }) => {

    const [product, setProduct] = useState(prod);

    return (
        <Col className="col-12 col-md-6 col-xl-3">
            <Card className="prod m-xs-4 ">
                <Card.Link href="#">
                    <Card.Img className="prod-img img-fluid" variant="top" src={`data:image/jpg;base64,${product.image}`} alt={product.title} />
                </Card.Link>
                <Card.Body className="prod-bod">
                    <Card.Title>{prod.title}</Card.Title>
                    <Card.Text className="description">{prod.description}</Card.Text>
                </Card.Body>
            </Card>
        </Col>
    );
}