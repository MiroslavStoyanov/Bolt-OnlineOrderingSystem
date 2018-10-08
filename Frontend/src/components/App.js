import React, {PropTypes, Component} from 'react';
import Header from './common/Header';
import injectTapEventPlugin from 'react-tap-event-plugin';
injectTapEventPlugin();
import LoginPage from './common/LogInPage';
import './App.css';

class App extends Component {
    constructor(props) {
        super(props);
        this.state = {
            loginPage: [],
            uploadScreen: []
        };
    }

    componentWillMount() {
        let loginPage = [];
        loginPage.push(<LoginPage parentContext={this} />);
        this.setState({
            loginPage: loginPage
        });
    }

    render() {
        return (
            <div className="App">
                <Header />
                {this.state.loginPage}
                {this.state.uploadScreen}
            </div>
        );
    }
}

App.propTypes = {
    children: PropTypes.object.isRequired
};

export default App;