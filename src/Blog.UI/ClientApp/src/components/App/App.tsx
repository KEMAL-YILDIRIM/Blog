import * as React from 'react';
import { Route } from 'react-router';
import Home from '../Home/Home';
import Layout from '../Layout';
import './App.css';


export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
    </Layout>
);
