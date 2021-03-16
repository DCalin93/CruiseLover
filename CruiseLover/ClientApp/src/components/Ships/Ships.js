import React, { Component } from 'react';
import '../CruiseDetailCard/CruiseDetail.css';


export class Ships extends Component {
    constructor() {
        super();
        this.state = {
            ships: []
        };
    }

    shouldComponentUpdate = (nextProps, nextState) => {
        if (this.state.ships != nextState.ships) {
            return true;
        }
        return false;
    }

    componentDidMount() {
        this.populateShipsTable();
    }

    getRandomBackgroundColor = () => {
        var colors = ['coral', 'cornflowerblue', 'darkslateblue', 'forestgreen', 'indigo', 'darkturqoise', 'navy', 'mediumseagreen', 'tomato', 'olivedrab'];
        return { backgroundColor: colors[Math.floor(Math.random() * colors.length)] };
    }

    getCardImage = () => {
        var randomNumber = Math.floor(Math.random() * 14);
        console.log(randomNumber);
        return ('/images/ships/ship_' + randomNumber + '.jpg');
    }

    render() {
        return (

            <div>
                {this.state.ships.map(ship =>
                    <div className="cruiseDetailCard" style={this.getRandomBackgroundColor()} >
                        <div className="cardImages">
                            <img className="cruise-bg grow" src={'/images/ships/ship_' + ship.id + '.jpg'}/>
                        </div>
                        <div className="cruiseInfo-container">
                            <div className="cruiseInfo-header">
                                <h1>{ship.name}</h1>
                            </div>
                            <p className="cruiseInfo-text">{ship.description}</p>
                        </div>
                    </div>
                )}
            </div>
        );
    }

    async populateShipsTable() {
        const response = await fetch('ship');
        const data = await response.json();
        this.setState({ ships: data });
    }
}