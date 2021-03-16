import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    render() {
        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white box-shadow" light>
                    <Container>
                        <NavbarBrand tag={Link} to="/"><img src={('/images/icon.png')}/></NavbarBrand>
                        <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                        <Collapse className="d-sm-inline-flex" isOpen={!this.state.collapsed} navbar>
                            <ul className="navbar-nav flex-grow ml-2">
                                <NavItem>
                                    <NavLink tag={Link} to="/cruiseDetails">Find a cruise</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} to="/deals">Best Deals</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} to="/destinations">Destinations</NavLink>
                                </NavItem>
                                <NavItem>
                                    <NavLink tag={Link} to="/ships">Ships</NavLink>
                                </NavItem>
                            </ul>
                            <ul className="navbar-nav flex-grow ml-auto">
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
    }
}
