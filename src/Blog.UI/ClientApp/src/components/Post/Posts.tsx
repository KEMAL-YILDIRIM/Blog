import { RootState } from 'InternalTypes'
import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { httpStatus } from '../../common/constants'
import { Post } from './Post'
import { fetchPosts } from './postSlice'


const Posts = () => {

  const dispatch = useDispatch()
  const { posts, error, status } = useSelector((state: RootState) => state.post)

  
  const postList = posts.map((item) => <Post
    AvatarInitials='K'
    PostBody={item.body}
    CardTitle={item.id}
    PostDate={new Date()}
    PostTitle={item.title}
    PostImageUrl={'https://picsum.photos/500/200'}
    key={item.id}
  />)

  useEffect(() => {
    dispatch(fetchPosts())
  },[dispatch])

  if (error) {
    return (
      <div>
        <h1>Something went wrong...</h1>
        <div>{error.toString()}</div>
      </div>
    )
  }
  
  if (status !== httpStatus.succeeded)
  return (<h3>Loading...</h3>)
  

  return <React.Fragment>
    {postList}
  </React.Fragment>
}

export default Posts
