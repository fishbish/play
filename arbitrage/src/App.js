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
      return <Form.Select placeholder="Loading Currencies" disabled />
    } else {
      var currencies = [];
      for (var currency in this.state.currencies) {
        currencies.push(currency);
      }
      return <Form.Select placeholder='LoadingCurrencies'>
          {currencies.map((currency) => {
            return <option key={currency}>{currency}</option>
          })}
      </Form.Select>
    }
  }

  render() {
    const disabled = this.state.currencies === null;

    return (
      <div className="App">
        <header className="App-header">
          <p>
            Select a base currency
          </p>
          <Form>
            {this.renderCurrencyDropDown()}
            <Button type="submit" disabled={disabled}>{disabled ? "Loading currencies" : "Maximise Arbitrage"}</Button>
          </Form>
        </header>
      </div>
    );
  }
}

export default App;
