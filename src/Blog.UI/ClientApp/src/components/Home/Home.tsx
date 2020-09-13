import * as React from 'react';
import { connect } from 'react-redux';
import Posts from '../Post/Posts';

const Home = () => (
  <React.Fragment>
    <Posts/>
  </React.Fragment>
);

export default connect()(Home);
