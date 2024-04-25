import { BookShopApiUrls, bookShopApiInstance } from './BookShopApiUrls';

export default class AuthApiService {
    static async loginByNameAndPassword(userName, password) {
        const response = await bookShopApiInstance.post(`${BookShopApiUrls.authLoginByUserNameAndPasswordUrl}`, { userName, password });
        return response;
    }
}