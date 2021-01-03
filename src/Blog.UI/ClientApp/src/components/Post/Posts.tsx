import { RootState } from 'InternalTypes'
import React from 'react'
import { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { Post } from './Post'
// import { httpStatus } from '../../common/constants'
import { fetchPosts } from './postSlice'

const Posts = () => {
    const dispatch = useDispatch()
    const { posts, error, status } = useSelector((state: RootState) => state.post)

    useEffect(() => {
        dispatch(fetchPosts())
    }, [])

    if (error) {
        return (
          <div>
            <h1>Something went wrong...</h1>
            <div>{error.toString()}</div>
          </div>
        )
      }

    const postList = posts.map(()=><Post/>)

    return <React.Fragment>

    </React.Fragment>
}

export default Posts
