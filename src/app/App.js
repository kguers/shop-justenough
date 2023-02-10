import React from "react";
import store from './store';
import 'bootstrap/dist/css/bootstrap.min.css';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import { Provider } from "react-redux";
import { Navigation } from "../components/navigation/navigation";

export const App = () => {

  return (
    <Provider store={store}>
      <Container fluid>
        <Row>
          <Navigation />
        </Row>
      </Container>
    </Provider>
  );
}

export default App;
