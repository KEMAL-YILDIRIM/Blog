import Axios from 'axios'
import Post from './postType'


export async function getAllPosts() {
    const url = 'https://jsonplaceholder.typicode.com/posts'
    const {data} = await Axios.get<Post[]>(url)
    return data;
}

export async function getPostById(id: number) {
    const url = `https://jsonplaceholder.typicode.com/post/${id}`
    const {data} = await Axios.get<Post>(url)
    return data;
}