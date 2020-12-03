import React from 'react'
import { useEffect } from 'react'

export const Posts = () => {

    useEffect(() => {
        if (postStatus === 'idle') {
          dispatch(fetchPosts())
        }
      }, [postStatus, dispatch])
    

      
      
    return (
        <React.Fragment>
            
        </React.Fragment>
    )
}