import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home/Home';
import { Users } from './components/Users/Users';
import { Login } from './components/Login/Login';
import './App.css'
import { CruiseDetailCard } from './components/CruiseDetailCard/CruiseDetailCard';
import { Deals } from './components/Deals/Deals';
import { Destinations } from './components/Destinations/Destinations';
import { Ships } from './components/Ships/Ships';


export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/users' component={Users} />
                <Route path='/login' component={Login} />
                <Route path='/cruiseDetails' component={CruiseDetailCard} />      
                <Route path='/ships' component={Ships} />
                <Route path='/deals' component={Deals} />
                <Route path='/destinations' component={Destinations} />
            </Layout>
        );
    }
}
