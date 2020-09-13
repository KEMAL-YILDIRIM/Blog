import React from 'react'
import { connect } from 'react-redux'

export const Compose = () => {
    return (
        <React.Fragment>
            
        </React.Fragment>
    )
}

Compose.propTypes = {
    
}

const mapStateToProps = (state:any) => ({
    CurrentUser : state.currentUser
})

const mapDispatchToProps = {
    
}

export default connect(mapStateToProps, mapDispatchToProps)(Compose)
