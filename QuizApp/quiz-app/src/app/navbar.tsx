import * as React from 'react';
import { Link } from 'react-router-dom';
import Navbar from 'react-bootstrap/Navbar';
import Nav from 'react-bootstrap/Nav';

export default class NavBar extends React.Component {

  public render() {
    return (
        <Navbar expand="sm" className="navbar-wrapper">
            <Navbar.Brand className="logo">
                Quiz
            </Navbar.Brand>
            <Navbar.Toggle className="push-right" />
            <Navbar.Collapse>
                <Nav className="push-right align-center">
                    <span className="nav-menu-item">
                        <Link
                            className="nav-link nav-menu-item-link"
                            to="/">
                            Home
                        </Link>
                    </span>
                    <span className="nav-menu-item">
                        <Link
                            className="nav-link nav-menu-item-link"
                            to="/login">
                            Login
                        </Link>
                    </span>
                    <span className="nav-menu-item">
                        <Link
                            className="nav-link nav-menu-item-link"
                            to="/register">
                            Register
                        </Link>
                    </span>
                </Nav>
            </Navbar.Collapse>
        </Navbar>
    );
  }
}
