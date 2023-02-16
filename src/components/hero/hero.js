import React from "react";
import './hero.css';
import {Row, Col, Button, Carousel} from 'react-bootstrap';
export const Hero = () => {

    return (
        <Row className="justify-content-center hero">
            <Col align="center" xs={{ span: 4 }} className=" hero-left">
                <h4 className="tagline">Podcast merch for you</h4>
            </Col>

            <Col align="center" xs={{ span: 6, offset: 1 }}>
                <Carousel>
                    <Carousel.Item>
                        <img
                            className="carousel-img d-block w-100 rounded"
                            src="./images/podcast-mic.jpg"
                            alt="First slide"
                        />
                        <Carousel.Caption>
                            <Button><h4>Microphones</h4></Button>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img
                            className="carousel-img d-block w-100 rounded"
                            src="./images/podcast-headphones.jpg"
                            alt="Second slide"
                        />
                        <Carousel.Caption>
                            <Button><h3>Headphones</h3></Button>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img
                            className="carousel-img d-block w-100 rounded"
                            src="./images/podcast-switch.jpg"
                            alt="Third slide"
                        />
                        <Carousel.Caption>
                            <Button><h3>Audio Switches</h3></Button>
                        </Carousel.Caption>
                    </Carousel.Item>
                </Carousel>
            </Col>
        </Row>
    );
}