import React, { Component } from 'react';
import { render } from "react-dom";
// import { Button, Dropdown } from 'bootstrap';
// import { DropdownButton } from 'react-bootstrap';
// import { ButtonGroup } from 'reactstrap';
import Button from 'react-bootstrap/Button';
import ButtonGroup from 'react-bootstrap/ButtonGroup';
import Dropdown from 'react-bootstrap/Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';
import Card from 'react-bootstrap/Card';
import Table from 'react-bootstrap/Table'

export class Home extends Component {
  static displayName = Home.name;
   engineList = [
        { name: "InfoTrack Engine", field: "custom" },
        { name: "Google", field: "google" },
        { name: "Bing", field: "bing" },
    ]
  constructor(props) {
    super(props);

    this.state = {
      searchEngine: { name: "InfoTrack Engine", field: "custom" },
      searchQuery: '',
      positionNumber: 0,
      results: []
    }
  }

  onSearchEngineChange = (e) => {
    var engine = this.engineList.find(engine => engine.field == e);
    this.setState({
      searchEngine: engine
    });
  }

  handleChange = (event) => {
    this.setState({
      searchQuery: event.target.value
    });
  }

  getSearchResults = async () => {
    const searchEngineName = this.state.searchEngine.field;
    const searchQuery = this.state.searchQuery;
    const url = `api/search/${searchEngineName}/${encodeURIComponent(searchQuery)}`;
    const response = await fetch(url);
    const data = await response.json();
    this.setState({ results: data, loading: false });

    if (data && data.length > 0) {
      const positionIndex = data.findIndex((item) => item.linkLabel.toLowerCase().includes("infotrack"));
      this.setState({positionNumber: positionIndex +1})
    }
  }

  render () {

    var engineUiList = this.engineList.map(function(engine) {
      return (<Dropdown.Item key={engine.field} eventKey={engine.field}>{engine.name}</Dropdown.Item>);
    });

    return (

      <Card>
        <Card.Header>Search Website position</Card.Header>
        <Card.Body>
        <ButtonGroup>
            <DropdownButton as={ButtonGroup} title={this.state.searchEngine.name} id="bg-nested-dropdown"
            onSelect={this.onSearchEngineChange}>
              { engineUiList }
            </DropdownButton>
            <input type="text" id="myInput" placeholder="Search here.." title="Type in a name" onChange={this.handleChange}></input>
            <Button onClick={this.getSearchResults}>Search</Button>
          </ButtonGroup>

          <p>Infotrack is at position {this.state.positionNumber}</p>

          <Table striped bordered hover>
            <thead>
              <tr>
                <th>Result Header</th>
              </tr>
            </thead>
            <tbody>
              {
                this.state.results.map(label => <tr><td>{label.linkLabel}</td></tr>)
              }
            </tbody>
            </Table>
        </Card.Body>
      </Card>
    );
  }
}
