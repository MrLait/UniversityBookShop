// @ts-nocheck
import axios from 'axios';

import { BookShopApiUrls } from './BookShopApiUrls';

const apiInstance = axios.create({
    baseURL: BookShopApiUrls.universityBookShopApiBaseURL,
});

export default class UniversityApiService {

    static async getAll() {
        const response = await apiInstance.get(BookShopApiUrls.university);
        return response;
    }

    static async getAllWithPagination(pageIndex, pageSize) {
        const response = await apiInstance.get(BookShopApiUrls.university,
            BookShopApiUrls.getPaginationParams(pageIndex, pageSize));
        return response;
    }

    static async getUniversityByUniversityIdWithPaginatedFaculties(universityId, pageIndex, pageSize) {
        const response = await apiInstance
            .get(`${BookShopApiUrls.university}/${universityId}`,
                BookShopApiUrls.getPaginationParams(pageIndex, pageSize));
        const { data } = response;
        return {
            university: (({ facultiesWithPagination, ...universityData }) => universityData)(data?.data),
            faculties: data?.data?.facultiesWithPagination?.items,
            validationError: data?.error,
            validationIsSucceeded: data?.isSucceeded,
            facultyPaginationData: (({ items, ...paginationData }) => paginationData)(data?.data?.facultiesWithPagination),
        };
    }

    static async delete(id) {
        const response = await apiInstance.delete(`${BookShopApiUrls.university}/${id}`);
        return response;
    }

    static async post(university) {
        const response = await apiInstance.post(`${BookShopApiUrls.university}/`, university);
        return response;
    }
}