import React from 'react'
import { connect } from 'react-redux'
import { ReviewCard, ReviewCardProps } from '../ReviewCard/ReviewCard'

export type PostProps = ReviewCardProps & {

}

export const Post = (props: PostProps) => {
  return <React.Fragment>
    <ReviewCard {...props} />
  </React.Fragment>
}

const mapStateToProps = (state: any) => ({})

const mapDispatchToProps = {}

export default connect(mapStateToProps, mapDispatchToProps)(Post)
