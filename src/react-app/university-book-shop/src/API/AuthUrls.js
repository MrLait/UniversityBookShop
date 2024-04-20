import axios from 'axios';

import { BookShopApiUrls } from './BookShopApiUrls';

const apiUrl = axios.create({
    baseURL: BookShopApiUrls.universityBookShopApiBaseURL,
});

export default class AuthApiService {
    static async loginByNameAndPassword(userName, password) {
        const response = await apiUrl.post(`${BookShopApiUrls.authLoginByUserNameAndPasswordUrl}`, { userName, password });
        return response;
    }
}