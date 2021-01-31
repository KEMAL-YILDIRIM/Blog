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

export const fetchPosts = createAsyncThunk('post/fetchAll',
  async () => {
    const response = await getAllPosts()
    console.log(response)
    return response
  })

export const postSlice = createSlice({
  name: 'post',
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
      console.log(state.status)
    })
    builder.addCase(fetchPosts.fulfilled, (state, action) => {
      state.status = httpStatus.succeeded
      console.log(state.status)
      // Add any fetched posts to the array
      state.posts = action.payload
    })
    builder.addCase(fetchPosts.rejected, (state, action) => {
      state.status = httpStatus.failed
      console.log(state.status)
      state.error = action.error.message
    })
  }
})

export const { postUpdated, postAdded } = postSlice.actions
export default postSlice.reducer