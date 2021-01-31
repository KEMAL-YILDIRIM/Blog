import React from 'react'
import { connect } from 'react-redux'

export type PostProps = {

}

export const Post = (props: PostProps) => {
  return <React.Fragment>
  </React.Fragment>
}

const mapStateToProps = (state: any) => ({})

const mapDispatchToProps = {}

export default connect(mapStateToProps, mapDispatchToProps)(Post)
