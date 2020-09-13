import PropTypes from 'prop-types'
import React from 'react'
import { connect } from 'react-redux'

export const Posts = () => {
    return (
        <React.Fragment>
            
        </React.Fragment>
    )
}

Posts.propTypes = {
    list: PropTypes.array
}

const mapStateToProps = (stat:any) => ({
    
})

const mapDispatchToProps = {
    
}

export default connect(mapStateToProps, mapDispatchToProps)(Posts)
