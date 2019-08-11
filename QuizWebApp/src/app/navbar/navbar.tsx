import * as React from 'react';
import { Link } from 'react-router-dom';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';
import { Routes } from 'app/routes';

type Props = {
    isUserAuthenticated: boolean
    currentPath: string,
    logUserOut: Function
}

type State = {
    navExpanded: boolean
}

export default class NavBar extends React.Component<Props, State> {

    constructor(props: any) {
        super(props);

        this.state = {
            navExpanded: false
        }
    }

    setNavExpanded = (expanded: boolean) => {
        this.setState({
            navExpanded: expanded
        })
    }

    public render() {
        return (
            <Navbar
                expand="sm"
                className="navbar-wrapper"
                onToggle={this.setNavExpanded}
                expanded={this.state.navExpanded}>
                <Navbar.Brand className="logo">
                    Quiz
                </Navbar.Brand>
                <Navbar.Toggle className="push-right" />
                <Navbar.Collapse>
                    <Nav
                        className="push-right align-center">
                        <span
                            className={`${this.props.currentPath === Routes.Home.path ? 'active' : ''} nav-menu-item`}
                            onClick={() => this.setNavExpanded(false)}>
                            <Link
                                className="nav-link nav-menu-item-link"
                                to={Routes.Home.path}>
                                Home
                        </Link>
                        </span>
                        {!this.props.isUserAuthenticated &&
                            <span
                                className={`${this.props.currentPath === Routes.Login.path ? 'active' : ''} nav-menu-item`}
                                onClick={() => this.setNavExpanded(false)}>
                                <Link
                                    className="nav-link nav-menu-item-link"
                                    to={Routes.Login.path}>
                                    Login
                                </Link>
                            </span>}
                        {!this.props.isUserAuthenticated &&
                            <span
                                className={`${this.props.currentPath === Routes.Register.path ? 'active' : ''} nav-menu-item`}
                                onClick={() => this.setNavExpanded(false)}>
                                <Link
                                    className="nav-link nav-menu-item-link"
                                    to={Routes.Register.path}>
                                    Register
                                </Link>
                            </span>}
                        {this.props.isUserAuthenticated &&
                            <span
                                className="nav-menu-item"
                                onClick={() => this.setNavExpanded(false)}>
                                <span
                                    className="cursor-pointer nav-link nav-menu-item-link"
                                    onClick={() => this.props.logUserOut()}>
                                    Log Out
                                </span>
                            </span>}
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        );
    }
}