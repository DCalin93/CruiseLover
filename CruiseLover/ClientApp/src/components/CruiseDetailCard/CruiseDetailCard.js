import React, { Component } from 'react';
import Moment from 'moment';
import DestinationDropDown from './DestinationDropDown';
import NightsDropDown from './NightsDropDown';
import DepartureMonthPicker from './DepartureCalendar';
import { MDBTable, MDBTableBody } from 'mdbreact';
import { withRouter } from 'react-router-dom';
import 'react-month-picker/css/month-picker.css';
import './CruiseDetail.css';


export class CruiseDetailCard extends Component {
    constructor() {
        super();
        this.state = {
            cruiseDetailCard: [],
            nightsValue: '0',
            destinationValue: [],
            departureValue: '01/21'
        };

        this.handleFilter = this.handleFilter.bind();
    }
    shouldComponentUpdate = (nextProps, nextState) => {
        if (this.state.cruiseDetailCard != nextState.cruiseDetailCard) {
            return true;
        }
        return false;
    }

    componentDidMount() {
        if (this.props.location.pathname == "/cruiseDetails") {
            this.populateCruiseDetailTable();
        } else {
            var pathSplit = this.props.location.pathname.split("/");
            var querySplit = pathSplit[pathSplit.length - 1].split("&");
            this.getFilteredData(querySplit);
        }
    }

    componentDidUpdate(prevProps) {
        if (prevProps.match.params !== this.props.match.params) {
            this.getFilteredData();
        }
    }

    handleNumberOfNights = (data) => {
        this.setState({ nightsValue: data })
    }

    handleDestination = (data) => {
        this.setState({ destinationValue: data })
    }

    handleDepartureDate = (data) => {
        this.setState({ departureValue: data })
    }

    handleFilter = () => {
        var val = this.state.departureValue.split("/");
        var month = val[0];
        var year = val[1];
        this.getFilteredData();
        this.props.history.push('/cruiseDetails/' +
            this.state.nightsValue + "&" +
            JSON.stringify(this.state.destinationValue) + "&" +
            month + "&" + year);
    }

    handleError = (err) => {
        console.warn(err);
        return new Response(JSON.stringify({
            code: 400,
            message: 'Error while fetching data'
        }));
    };

    getRandomBackgroundColor = () => {
        var colors = ['coral', 'cornflowerblue', 'darkslateblue', 'forestgreen', 'indigo', 'darkturqoise', 'navy', 'mediumseagreen', 'tomato', 'olivedrab'];
        return { backgroundColor: colors[Math.floor(Math.random() * colors.length)] };
    }

    getCardImage = () => {
        var randomNumber = Math.floor(Math.random() * 14);
        return ('/images/cruise_' + randomNumber + '.jpg');
    }

    render() {
        return (

            <div>
                <div className="filterData">
                    <DestinationDropDown handleDestination={this.handleDestination} />
                    <NightsDropDown handleNumberOfNights={this.handleNumberOfNights} />
                    <DepartureMonthPicker handleDepartureDate={this.handleDepartureDate} />
                    <button className="applyFilter" onClick={this.handleFilter}>APPLY FILTER</button>
                </div>
                <MDBTable >
                    <MDBTableBody>
                    {this.state.cruiseDetailCard.map(cruiseDetailCard =>
                        <tr>
                            <div className="cruiseDetailCard" style={this.getRandomBackgroundColor()} >
                                <div>
                                    <img className="cruise-bg grow" src={this.getCardImage()} />
                                </div>
                                <div className="cruiseInfo-container">
                                    <div className="cruiseInfo-header">
                                        <h1>{cruiseDetailCard.name}</h1>
                                    </div>
                                    <p className="cruiseInfo-text">{cruiseDetailCard.nights} NIGHTS</p>
                                    <p className="cruiseInfo-text">{cruiseDetailCard.price} €</p>
                                    <p className="cruiseInfo-text">{cruiseDetailCard.itinerary}</p>
                                    <p className="cruiseInfo-text">DEPARTURE DATE: {Moment(cruiseDetailCard.departureDate).format('MM-DD-YYYY')}</p>
                                    <p className="cruiseInfo-text">SHIP NAME: {cruiseDetailCard.ship.name}</p>
                                </div>
                            </div>
                        </tr>
                        )}
                    </MDBTableBody>
                </MDBTable>
            </div>
        );
    }

    async populateCruiseDetailTable() {
        const response = await fetch('cruiseDetail').catch(this.errorHandler);
        const data = await response.json();
        this.setState({ cruiseDetailCard: data });
    }

    async getFilteredData(querySplit) {
        var response = '';
        if (querySplit == null) {
            var val = this.state.departureValue.split("/");
            var month = val[0];
            var year = val[1];
            response = await fetch('cruiseDetail/' +
                this.state.nightsValue + "&" +
                JSON.stringify(this.state.destinationValue) + "&" +
                month + "&" + year).catch(this.errorHandler);
        } else {
            response = await fetch('cruiseDetail/' + querySplit[0] + "&" + querySplit[1] + "&" + querySplit[2] + "&" + querySplit[3]);
        }
        const data = await response.json();
        this.setState({ cruiseDetailCard: data });
    }
}

export default CruiseDetailCard;