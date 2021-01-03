import React from 'react'
import { connect } from 'react-redux'
import ReviewCard from '../ReviewCard/ReviewCard'

export const Post = () => {
  return <React.Fragment>
  <ReviewCard {}/>
  </React.Fragment>
}

const mapStateToProps = (state: any) => ({})

const mapDispatchToProps = {}

export default connect(mapStateToProps, mapDispatchToProps)(Post)
