import * as React from 'react'
import { connect } from 'react-redux'
import Posts from '../../components/Post/Posts'
import ReviewCard from '../../components/ReviewCard/ReviewCard'

const Home = () => (
  <React.Fragment>
    <Posts />
  </React.Fragment>
)

export default connect()(Home)
