import React from "react";
import './hero.css';
import {Row, Col, Button, Carousel} from 'react-bootstrap';
export const Hero = () => {

    return (
        <Row className="justify-content-center hero">
            <Col align="center " xs={{ span: 4 }} className="d-none d-md-flex hero-left">
                <h4 className="tagline justify-content-center">Podcast merch for you</h4>
            </Col>

            <Col align="center" xs={{ span: 12 }} sm={{span: 8}} md={{span: 6}}>
                <Carousel className="hero-carousel">
                    <Carousel.Item>
                        <img
                            className="carousel-img d-block w-100 rounded"
                            src="./images/podcast-mic.jpg"
                            alt="First slide"
                        />
                        <Carousel.Caption>
                            <Button className="btn-carousel"><h4>Microphones</h4></Button>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img
                            className="carousel-img d-block w-100 rounded"
                            src="./images/podcast-headphones.jpg"
                            alt="Second slide"
                        />
                        <Carousel.Caption>
                            <Button className="btn-carousel"><h3>Headphones</h3></Button>
                        </Carousel.Caption>
                    </Carousel.Item>
                    <Carousel.Item>
                        <img
                            className="carousel-img d-block w-100 rounded"
                            src="./images/podcast-switch.jpg"
                            alt="Third slide"
                        />
                        <Carousel.Caption>
                            <Button className="btn-carousel"><h3>Audio Switches</h3></Button>
                        </Carousel.Caption>
                    </Carousel.Item>
                </Carousel>
            </Col>
        </Row>
    );
}