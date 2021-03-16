import React, { Component } from 'react';
import Moment from 'moment';
import '../CruiseDetailCard/CruiseDetail.css';


export class Deals extends Component {
    constructor() {
        super();
        this.state = {
            cruiseDetailCard: []
        };
    }

    shouldComponentUpdate = (nextProps, nextState) => {
        if (this.state.cruiseDetailCard != nextState.cruiseDetailCard) {
            return true;
        }
        return false;
    }

    componentDidMount() {
        this.populateCruiseDetailTable();
    }

    getRandomBackgroundColor = () => {
        var colors = ['coral', 'cornflowerblue', 'darkslateblue', 'forestgreen', 'indigo', 'darkturqoise', 'navy', 'mediumseagreen', 'tomato', 'olivedrab'];
        return { backgroundColor: colors[Math.floor(Math.random() * colors.length)] };
    }

    getCardImage = () => {
        var randomNumber = Math.floor(Math.random() * 14);
        console.log(randomNumber);
        return ('/images/cruise_' + randomNumber + '.jpg');
    }

    getOldPrice = (price, discount) => {
        return Math.floor(price / ((100 - discount * 100) / 100));
    }

    getDiscountPercentage = (discount) => {
        return discount * 100;
    }

    render() {
        return (

            <div>
                {this.state.cruiseDetailCard.map(cruiseDetailCard =>
                    <div className="cruiseDetailCard" style={this.getRandomBackgroundColor()} >
                        <div className="cardImages">
                            <img className="cruise-bg grow" src={this.getCardImage()} />
                            <img className="discountImage" src={('/images/discount.png')} />
                        </div>
                        <div className="cruiseInfo-container">
                            <div className="cruiseInfo-header">
                                <h1>{cruiseDetailCard.name}</h1>
                            </div>
                            <p className="cruiseInfo-text">{cruiseDetailCard.nights} NIGHTS</p>
                            <div className="priceContainer" >
                                <p className="cruiseInfo-text oldPrice">{this.getOldPrice(cruiseDetailCard.price, cruiseDetailCard.discount)} € </p>
                                <p className="cruiseInfo-text"> - {cruiseDetailCard.price} € - </p>
                                <p className="cruiseInfo-text discount">DISCOUNT {this.getDiscountPercentage(cruiseDetailCard.discount)}%</p>
                            </div>
                            <p className="cruiseInfo-text">{cruiseDetailCard.itinerary}</p>
                            <p className="cruiseInfo-text">DEPARTURE DATE: {Moment(cruiseDetailCard.departureDate).format('MM-DD-YYYY')}</p>
                            <p className="cruiseInfo-text">SHIP NAME: {cruiseDetailCard.ship.name}</p>
                        </div>
                    </div>
                )}
            </div>
        );
    }

    async populateCruiseDetailTable() {
        const response = await fetch('cruiseDetail/bestDeals');
        const data = await response.json();
        this.setState({ cruiseDetailCard: data });
    }
}