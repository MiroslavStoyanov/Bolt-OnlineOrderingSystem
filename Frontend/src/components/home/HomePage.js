import React from 'react';
import {Link} from 'react-router';

class HomePage extends React.Component {
    render() {
        return (
            <div className="jumbotron">
                <h1>Bolt Online Orderign</h1>
                <p>Welcome to Bolt Online Ordering.
                    Feel free to browse and get anything you find tasty and powerful enough to get you going!
                </p>
                <Link to="about" className="btn btn-primary btn-lg">Learn more</Link>
            </div>
        );
    }
}

export default HomePage;