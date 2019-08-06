import axios from 'axios';

export const getAllTopics = () => {
    return axios.get('http://192.168.1.7:44301/api/topics');
}