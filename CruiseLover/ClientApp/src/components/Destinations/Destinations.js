import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import '../CruiseDetailCard/CruiseDetail.css';

export class Destinations extends Component {
    constructor() {
        super();
        this.state = {
            destinations: [],
        };
    }

    shouldComponentUpdate = (nextProps, nextState) => {
        if (this.state.destinations != nextState.destinations) {
            return true;
        }
        return false;
    }

    componentDidMount() {
        this.populateDestinationsTable();
    }

    getRandomBackgroundColor = () => {
        var colors = ['coral', 'cornflowerblue', 'darkslateblue', 'forestgreen', 'indigo', 'darkturqoise', 'navy', 'mediumseagreen', 'tomato', 'olivedrab'];
        return { backgroundColor: colors[Math.floor(Math.random() * colors.length)] };
    }

    getCardImage = (destinationName) => {
        var destination = destinationName.toLowerCase().replace(' ', '_');
        return ('/images/destinations/' + destination + '.jpg');
    }

    render() {
        return (
            <div>
                {this.state.destinations.map(destination =>
                    <div className="cruiseDetailCard" style={this.getRandomBackgroundColor()} >
                        <div className="cardImages">
                            <img className="cruise-bg grow" src={this.getCardImage(destination.name)} />
                        </div>
                        <div className="cruiseInfo-container">
                            <div className="cruiseInfo-header">
                                <h1>{destination.name}</h1>
                            </div>
                            <p className="cruiseInfo-text">{destination.description}</p>
                            <Link className="bookCruise" to={'/cruiseDetails/0&["' + destination.name + '"]&01&21'}>Book a cruise to {destination.name}</Link>
                        </div>
                    </div>
                )}
            </div>
        );
    }


    async populateDestinationsTable() {
        const response = await fetch('destination/allDestinations');
        const data = await response.json();
        this.setState({ destinations: data });
    }

    async redirectToCruiseDetails(destinationName) {
        const response = await fetch('cruiseDetail/0&' +
            JSON.stringify(destinationName) + '&01&19');
        const data = await response.json();
        return data;
    }
}