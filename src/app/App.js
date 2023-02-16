import React from "react";
import store from './store';
import 'bootstrap/dist/css/bootstrap.min.css';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import { Provider } from "react-redux";
import { Navigation } from "../components/navigation/navigation";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Home } from "../components/home/home";
import { Footer } from "../components/footer/footer";
import { ProductList } from "../components/productlist/productlist";

export const App = () => {

  return (
    <Router>
      <Provider store={store}>

        <Container fluid >
          <Row>
            <Navigation />
          </Row>

          <Switch>
            <Row>
              
              <Route exact path="/">
                <Home />
              </Route>

              <Route path='/products:category'>
                <ProductList />
              </Route>

            </Row>
          </Switch>
          
          <Footer />
          
        </Container>

      </Provider>
    </Router>
  );
}

export default App;
