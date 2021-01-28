import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import { getAllPosts } from '../../api/postCalls'
import { httpStatus } from '../../common/constants'

interface PostsState {
  posts: any[]
  status: string
  error: string | null | undefined
}

export const initialState: PostsState = {
  posts: [],
  status: httpStatus.idle,
  error: null,
}

export const fetchPosts = createAsyncThunk('posts/fetchAll',
  async () => {
    const response = await getAllPosts()
    console.log(response)
    return response
  })

export const postsSlice = createSlice({
  name: 'posts',
  initialState,
  reducers: {
    postAdded(state, { payload }) {
      state.posts.push(payload)
    },
    postUpdated(state, { payload }) {
      const { id, title, content } = payload
      const existingPost = state.posts.find((post) => post.Id === id)
      if (existingPost) {
        existingPost.Title = title
        existingPost.Content = content
      }
    }
  },
  extraReducers: builder => {
    builder.addCase(fetchPosts.pending, (state, action) => {
      state.status = httpStatus.loading
    })
    builder.addCase(fetchPosts.fulfilled , (state, action) => {
      state.status = httpStatus.succeeded
      // Add any fetched posts to the array
      state.posts = state.posts.concat(action.payload)
    })
    builder.addCase(fetchPosts.rejected, (state, action) => {
      state.status = httpStatus.failed
      state.error = action.error.message
    })
  }
})

export const { postUpdated, postAdded } = postsSlice.actions
export default postsSlice.reducer