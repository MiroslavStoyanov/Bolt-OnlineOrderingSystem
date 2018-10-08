import React, {PropTypes} from 'react';

class RegisterPage extends React.Component {
    render() {
        return (
            <div className="container">
                <h1>Register</h1>
                <p>Please fill in this form to create an account.</p>
                <br/>
                <label htmlFor="username"><b>Username</b></label>
                <input type="text" placeholder="Enter Username" name="username" required></input>
                <br/>
                <label htmlFor="email"><b>Email</b></label>
                <input type="text" placeholder="Enter Email" name="email" required></input>
                <br/>
                <label htmlFor="psw"><b>Password</b></label>
                <input type="password" placeholder="Enter Password" name="psw" required></input>
                <br/>
                <label htmlFor="psw-repeat"><b>Repeat Password</b></label>
                <input type="password" placeholder="Repeat Password" name="psw-repeat" required></input>
                <br/>
                <p>By creating an account you agree to our <a href="#">Terms and Privacy</a>.</p>
                <button type="submit" className="registerbtn">Register</button>
            </div>
        );
    }
}

export default RegisterPage;