import axios from 'axios';

import { BookShopApiUrls } from './BookShopApiUrls';

const apiInstance = axios.create({
    baseURL: BookShopApiUrls.universityBookShopApiBaseURL,
});

export default class PurchasedBookApiService {
    static async getAll() {
        const response = await apiInstance.get(`${BookShopApiUrls.purchasedBookFaculty}/`);
        return response;
    }

    static async getByFacultyId(facultyId) {
        const response = await apiInstance.get(`${BookShopApiUrls.purchasedBookByFacultyId}/${facultyId}`);
        return response;
    }

    static async getByUniversityId(universityId) {
        const response = await apiInstance.get(`${BookShopApiUrls.purchasedBookByUniversityId}/${universityId}`);
        return response;
    }

    static async postPurchaseBookForFaculty(bookId, facultyId) {
        const response = await apiInstance.post(`${BookShopApiUrls.purchasedBookFaculty}/`, { bookId, facultyId });
        return response;
    }

    static async delete(id) {
        const response = await apiInstance.delete(`${BookShopApiUrls.purchasedBookFaculty}/${id}`);
        return response;
    }

    static async deleteByFacultyIdAndBookId(facultyId, bookId) {
        const response = await apiInstance.delete(`${BookShopApiUrls.purchasedBookFaculty}/faculty/${facultyId}/book/${bookId}`);
        return response;
    }


}