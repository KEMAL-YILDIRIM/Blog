import * as React from 'react';
import { Route } from 'react-router';
import Home from '../pages/Home/Home';
import Layout from '../pages/Layout/Layout';
import './App.css';


export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
    </Layout>
);
