import React, {PropTypes} from 'react';
import { Link, IndexLink } from 'react-router';

const Header = () => {
    return (
        <nav>
            <IndexLink to="/" activeClassName="active">Home</IndexLink>
            {" | "}
            <Link to="/menu" activeClassName="active">Menu</Link>
            {" | "}
            <Link to="/about" activeClassName="active">About</Link>
            {" | "}
            <Link to="/cart" activeClassName="active">Cart</Link>
            {" | "}
            <Link to="/login" activeClassName="active">Sign In</Link>
            {" | "}
            <Link to="/register" activeClassName="active">Register</Link>
        </nav>
    );
};

export default Header;