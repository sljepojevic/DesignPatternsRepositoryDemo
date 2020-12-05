import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { students: [], loading: true };
  }

  componentDidMount() {
    this.populateStudentData();
  }

  static renderForecastsTable(students) {
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
          {students.map(student =>
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
        : FetchData.renderForecastsTable(this.state.students);

    return (
        <div>
          <h1 id="tabelLabel" >Students</h1>
          <p>This component demonstrates fetching data from the server.</p>
          {contents}
        </div>
    );
  }

  async populateStudentData() {
    const response = await fetch('student');
    const data = await response.json();
    this.setState({ students: data, loading: false });
  }
}
