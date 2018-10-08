import React, { Component } from 'react';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import RaisedButton from 'material-ui/RaisedButton';
import Login from '../login/Login';
import Register from '../register/Register';

class LoginPage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: '',
            password: '',
            loginscreen: [],
            loginmessage: '',
            buttonLabel: 'Register',
            isLogin: true
        };
    }

    componentWillMount() {
        let loginScreen = [];

        loginScreen.push(
        <Login 
            parentContext={this} 
            appContext={this.props.parentContext}    
        />);

        const loginMessage = "Not registered yet. Register Now!";

        this.setState({
            loginScreen: loginScreen,
            loginMessage: loginMessage
        });
    }

    render() {
        return (
            <div className="loginscreen">
            {this.state.loginscreen}
                <div>
                {this.state.loginmessage}
                    <MuiThemeProvider>
                        <div>
                            <RaisedButton 
                                label={this.state.buttonLabel} 
                                primary 
                                style={style} 
                                onClick={(event) => this.handleClick(event)}
                            />
                        </div>
                    </MuiThemeProvider>
                </div>
            </div>
        );
    }
}

const style = {
    margin: 15
  };

export default LoginPage;