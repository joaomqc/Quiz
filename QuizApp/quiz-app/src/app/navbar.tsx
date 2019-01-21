import * as React from 'react';
import { Link } from 'react-router-dom';

export default class NavBar extends React.Component {
  public render() {
    return (
      <nav className="navbar">
        <div className="nav-wrapper">
          <div className="logo">
            Quiz
          </div>
          <div className="nav-menu">
            <div className="nav-menu-item">
              <Link
                className="nav-menu-item-link"
                to="/">
                Home
              </Link>
            </div>
          </div>
        </div>
      </nav>
    );
  }
}
