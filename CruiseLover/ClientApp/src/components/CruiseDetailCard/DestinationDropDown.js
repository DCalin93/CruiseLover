import React, { Component } from 'react';
import DropdownMultiselect from "react-multiselect-dropdown-bootstrap";

export class DestinationDropDown extends Component {
    constructor(props) {
        super(props);
        this.state = { destinations: null, dropdownValue: [] };
    }

    componentDidMount() {
        this.populateDestinations();
    }

    handleDestination = (event) => {
        this.state({ dropdownValue: event })
    }

    render() {

        if (!this.state.destinations) return null;

        return (
            <div className="zoneSelect">
                <p>DESTINATIONS:</p>
                <DropdownMultiselect
                    options={this.state.destinations}
                    handleOnChange={(selected) => this.props.handleDestination(selected)}
                    placeholder="Select a destination"
                />
            </div>
        );
    }

    async populateDestinations() {
        const response = await fetch('destination');
        const data = await response.json();
        this.setState({ destinations: data });
    }
}

export default DestinationDropDown;