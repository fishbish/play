import React from 'react';
import axios from 'axios';
import { Form, Button } from 'react-bootstrap';
import './App.css';

const apikey = "KZlX04QDIvYSVKwG2oITsrmCTQZWrbJBK55df8Sf";

class App extends React.Component {

  constructor() {
    super();
    this.state = {currencies: null};
  }

  async componentDidMount() {    
    const response = await axios.get("https://api.currencyapi.com/v3/currencies?currencies=", {headers: {apikey: apikey}});
    console.log(response.data.data);
    this.setState({currencies: response.data.data});
  }

  renderCurrencyDropDown() {
    if (this.state.currencies === null) {
      return <div>Loading currencies...</div>;
    } else {
      var currencies = [];
      for (var currency in this.state.currencies) {
        currencies.push(currency);
      }
      return <Form.Select>
          {currencies.map((currency) => {
            return <option key={currency}>{currency}</option>
          })}
      </Form.Select>
    }
  }

  render() {
    return (
      <div className="App">
        <header className="App-header">
          <p>
            Select a base currency
          </p>
          <Form>
            {this.renderCurrencyDropDown()}
            <Button type="submit">Maximise Arbitrage</Button>
          </Form>
        </header>
      </div>
    );
  }
}

export default App;
