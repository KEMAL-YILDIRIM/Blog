import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { getAllPosts } from '../../api/postCalls';
import { httpStatus } from '../../common/Constants';


interface PostsState {
    posts: [],
    status: string,
    error: string | null
}

const initialState: PostsState = {
    posts: [],
    status: httpStatus.idle,
    error: null
}

export const postsSlice = createSlice({
    name: 'posts',
    initialState,
    reducers: {
        postAdded(state, { payload }) {
            state.posts.push(payload)
        },
        postUpdated(state, { payload }) {
            const { id, title, content } = payload
            const existingPost = state.posts.find(post => post.Id === id)
            if (existingPost) {
                existingPost.Title = title;
                existingPost.Content = content;
            }
        },
        postsFetched(state, action) {
            state.posts = action.payload;
        }
    }, extraReducers: {
        [fetchPosts.loading]: (state, action) => {
            state.status = 'loading'
        },
        [fetchPosts.succeeded]: (state, action) => {
            state.status = 'succeeded'
            // Add any fetched posts to the array
            state.posts = state.posts.concat(action.payload)
        },
        [fetchPosts.failed]: (state, action) => {
            state.status = 'failed'
            state.error = action.error.message
        }
    }
})

export const fetchPosts = createAsyncThunk('posts/fetchPosts', getAllPosts)

export const {
    postUpdated,
    postAdded,
    postsFetched
} = postsSlice.actions;
export default postsSlice.reducer;