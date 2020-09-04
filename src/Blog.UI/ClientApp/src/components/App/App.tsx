import * as React from 'react';
import { Route } from 'react-router';
import Layout from '../Layout';
import Home from '../Home';
import Counter from '../Counter';
import FetchData from '../FetchData';

import './App.css'

export default () => (
    <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data/:startDateIndex?' component={FetchData} />
    </Layout>
);
