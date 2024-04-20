import axios from 'axios';

import { BookShopApiUrls } from './BookShopApiUrls';

const apiInstance = axios.create({
    baseURL: BookShopApiUrls.universityBookShopApiBaseURL,
});

apiInstance.interceptors.request.use(config => {
    // Retrieve the access token from React state or a state management system
    const accessToken = `${localStorage.getItem('accessToken')}`;
    // Add the access token to the Authorization header
    config.headers.Authorization = `Bearer ${accessToken}`;
    return config;
});

// apiInstance.interceptors.request.use(
//     (config) => {
//         const token = `${localStorage.getItem('accessToken')}`;
//         const auth = token ? `Bearer ${token}` : '';
//         config.headers.common['Authorization'] = auth;
//         return config;
//     },
//     (error) => {
//         Promise.reject(error);
//     },
// );

export default class BookApiService {

    static async getAll() {
        const response = await apiInstance.get(`${BookShopApiUrls.book}/`);
        return response;
    }

    static async getBooksWithPurchaseStatusByFacultyIdWithPagination(facultyId, pageIndex, pageSize) {
        const response = await apiInstance.get(`${BookShopApiUrls.book}/${BookShopApiUrls.faculty}/${facultyId}`,
            BookShopApiUrls.getPaginationParams(pageIndex, pageSize),
        );
        const { data } = response;
        return {
            books: data.data.items,
            validationError: data.error,
            validationIsSucceeded: data.isSucceeded,
            paginationData: (({ items, ...paginationData }) => paginationData)(data.data),
        };
    }
}
