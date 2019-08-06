import axios from 'axios';

export function get(endpoint: string) {
    return axios.get(endpoint);
}

export function post(endpoint: string, data: Object) {
    return axios.post(endpoint, data);
}
