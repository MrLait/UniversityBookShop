import axios from 'axios';

import { BookShopApiUrls, bookShopApiInstance } from './BookShopApiUrls';

export default class BooksPurchasedByUniversityApiService {
    static async getAll() {
        const response = await bookShopApiInstance.get(`${BookShopApiUrls.booksPurchasedByUniversity}/`);
        return response;
    }
    static async getIsBookAtUniversity(bookId, universityId) {
        const response = await bookShopApiInstance.get(`${BookShopApiUrls.booksPurchasedByUniversity}/${bookId}/${universityId}`);
        return response;
    }
}
