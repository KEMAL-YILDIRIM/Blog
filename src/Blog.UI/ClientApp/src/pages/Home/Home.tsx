import * as React from 'react'
import { connect } from 'react-redux'
import Posts from '../../components/Post/Posts'

const Home = () => (
  <React.Fragment>
    <Posts />
  </React.Fragment>
)

export default connect()(Home)
