import React, { Component } from 'react';
import { Home } from './components/Home';
import 'bootstrap/dist/css/bootstrap.min.css';
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Home></Home>
    );
  }
}
