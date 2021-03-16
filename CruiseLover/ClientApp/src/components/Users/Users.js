import React, { Component } from 'react';

export class Users extends Component {
    constructor(props) {
        super(props);
        this.state = { users: [] };
    }

    componentDidMount() {
        this.populateUsersTable();
    }

    static renderUsersTable(users) {
        return (
            <table className='table table-striped' aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>E-mail</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map(user =>
                        <tr key={user.id}>
                            <td>{user.id}</td>
                            <td>{user.firstName}</td>
                            <td>{user.lastName}</td>
                            <td>{user.email}</td>
                        </tr>
                    )}
                </tbody>
            </table>         
        );
    }

    render() {
        let contents = Users.renderUsersTable(this.state.users);

        return (
            <div>
                <h1 id="tableLabel">Users</h1>
                {contents}
            </div>    
        );
    }

    async populateUsersTable() {
        const response = await fetch('user');
        const data = await response.json();
        this.setState({ users: data });
    }
}