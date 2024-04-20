// @ts-nocheck
import axios from 'axios';

import { BookShopApiUrls } from './BookShopApiUrls';
const apiInstance = axios.create({
    baseURL: BookShopApiUrls.universityBookShopApiBaseURL,
});

apiInstance.interceptors.request.use(config => {
    // Retrieve the access token from React state or a state management system
    const accessToken = `${localStorage.getItem('accessToken')}`;
    // Add the access token to the Authorization header
    config.headers.Authorization = `Bearer ${accessToken}dasd`;
    return config;
});

export default class BooksAvailableForFacultyApiService {

    static async getAll() {
        const response = await apiInstance.get(`${BookShopApiUrls.booksAvailableForFaculty}/`);
        return response;
    }

    static async getByFacultyId(facultyId) {
        const response = await apiInstance.get(`${BookShopApiUrls.booksAvailableForFaculty}/${facultyId}`);
        return response;
    }

    static async getByFacultyIdWithPagination(facultyId, pageIndex, pageSize) {
        const response = await apiInstance.get(`${BookShopApiUrls.booksAvailableForFaculty}/${facultyId}`,
            BookShopApiUrls.getPaginationParams(pageIndex, pageSize));
        const { data } = response;
        return {
            availableBooks: data.data.items,
            validationError: data.error,
            validationIsSucceeded: data.isSucceeded,
            paginationData: (({ items, ...paginationData }) => paginationData)(data.data),
        };
    }

    static async getByFacultyIdBookId(facultyId, bookId) {
        const response = await apiInstance.get(`${BookShopApiUrls.booksAvailableForFaculty}/${facultyId}/${bookId}`);
        const { data } = response;
        return {
            availableBook: data.data,
            validationError: data.error,
            validationIsSucceeded: data.isSucceeded,
        };
    }

    static async postAddBook(bookId, facultyId) {
        const response = await apiInstance.post(`${BookShopApiUrls.addBooksAvailableForFaculty}/`, { bookId, facultyId });
        return response;
    }

    static async deleteAvailableBook(bookId) {
        const response = await apiInstance.delete(`${BookShopApiUrls.booksAvailableForFaculty}/${bookId}`);
        return response;
    }
}
