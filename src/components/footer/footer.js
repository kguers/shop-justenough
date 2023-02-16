import React from "react";
import "./footer.css";
import { Row, Col, Image } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"

export const Footer = () => {
    return (
        <Row className="footer accountForNav">
            <Col className="text-start align-self-center">
            <Image className="d-inline logo-footer" src="./images/justenough-logo.png" alt="Logo without wording" />        
            <p className="d-inline p-2 text-nowrap">&copy; Just Enough Podcast, LLC 2023 </p> 
            </Col>
            <Col className="align-self-center text-end col-3">
                <a href="https://github.com/kguers/shop.justenough.github.io" target="_blank" rel="noopener noreferrer">
                    <FontAwesomeIcon className="github footer-link" icon="fa-brands fa-github"/>
                </a>
            </Col>
        </Row>
    );
};