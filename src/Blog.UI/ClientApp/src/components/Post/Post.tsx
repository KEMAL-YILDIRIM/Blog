import React, { Component } from 'react'
import PropTypes from 'prop-types'
import { connect } from 'react-redux'

export const Post = () => {
    return (
        <React.Fragment>
            
        </React.Fragment>
    )
}

Post.propTypes = {
    prop: PropTypes
}

const mapStateToProps = (state) => ({
    
})

const mapDispatchToProps = {
    
}

export default connect(mapStateToProps, mapDispatchToProps)(Post)
