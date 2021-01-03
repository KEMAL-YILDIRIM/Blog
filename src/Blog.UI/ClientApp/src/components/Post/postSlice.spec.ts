import Post from '../../api/types'
import posts, { initialState, postAdded } from './postSlice'

describe('posts reducer', () => {
  it('should handle initial state', () =>
    expect(posts(undefined, {} as any)).toEqual([]))

  it('should handle POST_ADDED', () => {
    //Arrange
    const payload: Post = {
      Id: 0,
      Title: 'test',
      Content: 'test content',
    }

    //Act
    const result = posts(initialState, postAdded(payload))

    //Assert
    expect(result).toEqual([])
  })
})
