import axios from 'axios';

const api = axios.create({
    baseURL: 'https://192.168.15.15:45455/api',
});

export default api;
