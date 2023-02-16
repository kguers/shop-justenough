import React, { useState } from "react";
import { Container, Navbar, Nav, Form, Button, Row } from "react-bootstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faRightToBracket, faPersonRunning, faCartShopping } from '@fortawesome/free-solid-svg-icons';
import './navigation.css'

export const Navigation = () => {

    const [sign, setSign] = useState(false)

    return (
        <Navbar variant="pills" className="navbar fixed-top">
            <Container fluid>
                <Navbar.Brand className="logo ms-4">
                    <img
                        className='logo-img'
                        src='./images/justenough.png'
                        alt='Just Enough Logo'
                    />
                </Navbar.Brand>
                <Form className="d-none d-sm-flex searchBar">
                    <Form.Control
                        type="search"
                        placeholder="Search for Product"
                        className="me-2 bar"
                        aria-label="Search"
                    />
                    <Button variant="primary">Search</Button>
                </Form>
                <Nav>
                    <Button
                        onMouseEnter={() => setSign(true)}
                        onMouseLeave={() => setSign(false)}
                        className="me-2 navRightButtons"
                    >
                        {!sign
                            ?
                            <FontAwesomeIcon
                                icon={faRightToBracket}
                            />
                            :
                            <FontAwesomeIcon
                                icon={faPersonRunning}
                            />
                        }
                    </Button>
                    <Button
                        className="me-2 navRightButtons"
                    >
                        <FontAwesomeIcon
                            icon={faCartShopping}
                        />
                    </Button>
                </Nav>
            </Container>
        </Navbar >
    );
}