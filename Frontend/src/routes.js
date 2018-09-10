import React from 'react';
import { Route, IndexRoute } from 'react-router';
import App from './components/App';
import HomePage from './components/home/HomePage';
import AboutPage from './components/about/AboutPage';
import MenuPage from './components/menu/MenuPage';
import CartPage from './components/cart/CartPage';
import LogInPage from './components/common/LogInPage';
import RegisterPage from './components/common/RegisterPage';

export default (
    <Route path="/" component={App}>
        <IndexRoute component={HomePage} />       
        <Route path="menu" component={MenuPage} />
        <Route path="about" component={AboutPage} />
        <Route path="cart" component={CartPage} />
        <Route path="login" component={LogInPage} />
        <Route path="register" component={RegisterPage} />
    </Route>
);