// @ts-nocheck
import axios from 'axios';

import { Currencies } from '../components/constants/initialStates';

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
        const { data } = response;
        return {
            universities: data?.data?.items,
            validationError: data?.error,
            validationIsSucceeded: data?.isSucceeded,
            paginationData: (({ items, ...paginationData }) => paginationData)(data?.data),
        };
    }

    static async getUniversityByUniversityIdWithPaginatedFaculties(universityId, pageIndex, pageSize) {
        const response = await apiInstance.get(`${BookShopApiUrls.university}/${universityId}`,
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

    static async deleteUniversityByUniversityId(universityId) {
        const response = await apiInstance.delete(`${BookShopApiUrls.university}/${universityId}`);
        return response;
    }

    static async post(university) {
        university.currencyCodeId = Currencies.Usd;
        const response = await apiInstance.post(`${BookShopApiUrls.university}/`, university);
        return response;
    }
}