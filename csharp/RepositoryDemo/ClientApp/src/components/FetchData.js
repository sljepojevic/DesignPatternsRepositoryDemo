import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderForecastsTable(forecasts) {
    return (
        <table className='table table-striped' aria-labelledby="tabelLabel">
          <thead>
          <tr>
            <th>Id</th>
            <th>First Name</th>
            <th>Last Name</th>
          </tr>
          </thead>
          <tbody>
          {forecasts.map(student =>
              <tr key={student.studentId}>
                  <td>{student.studentId}</td>
                  <td>{student.firstName}</td>
                  <td>{student.lastName}</td>
              </tr>
          )}
          </tbody>
        </table>
    );
  }

  render() {
    let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : FetchData.renderForecastsTable(this.state.forecasts);

    return (
        <div>
          <h1 id="tabelLabel" >Weather forecast</h1>
          <p>This component demonstrates fetching data from the server.</p>
          {contents}
        </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('student');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}