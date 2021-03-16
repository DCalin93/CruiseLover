import React, { Component } from 'react';
import MonthPickerInput from 'react-month-picker-calendar';
import "react-month-picker-calendar/dist/react-month-picker-input.css";

export class DepartureMonthPicker extends Component {

    constructor(props) {
        super(props);
        this.state = {
            departureValue: ''
        };
    }

    handleDepartureDate = (event) => {
        this.setState({ departureValue: event })
    }

    render() {

        return (
            <div className="departureSelect">
                <p>DEPARTURE AFTER:</p>
                <div >
                    <MonthPickerInput
                        onChange={(maskedValue) =>
                            this.props.handleDepartureDate(maskedValue)}
                        year={2021}
                        month={1}
                    />
                </div>
            </div>
        )
    }
}

export default DepartureMonthPicker;

