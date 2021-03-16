import React, { Component } from 'react';

export class NightsDropDown extends Component {
    constructor() {
        super();
        this.state = {
            value: '1'
        };
    }

    handleNumberOfNights = (event) => {
        this.setState({ value: event });
    }

    render() {
        return (
            <div className="nightSelect">
                <p>NUMBER OF NIGHTS</p>
                <select className="form-control" name="nights"
                    onChange={(ev) => this.props.handleNumberOfNights(ev.target.value)}
                >
                    <option selected value="0">Select number of nights</option>
                    <option value="24">2-4 nights</option>
                    <option value="57">5-7 nights</option>
                    <option value="810">8-10 nights</option>
                    <option value="11">11+ nights</option>
                </select>
            </div>
        );
    }
}

export default NightsDropDown;
