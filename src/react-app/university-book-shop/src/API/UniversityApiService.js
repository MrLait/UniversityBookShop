import { Currencies } from '../components/constants/initialStates';

import { BookShopApiUrls, bookShopApiInstance, bookShopApiPrivateInstance } from './BookShopApiUrls';

export default class UniversityApiService {

    static async getAll() {
        const response = await bookShopApiInstance.get(BookShopApiUrls.university);
        return response;
    }

    static async getAllWithPagination(pageIndex, pageSize) {
        const response = await bookShopApiInstance.get(BookShopApiUrls.university,
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
        const response = await bookShopApiInstance.get(`${BookShopApiUrls.university}/${universityId}`,
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
        const response = await bookShopApiPrivateInstance.delete(`${BookShopApiUrls.university}/${universityId}`);
        return response;
    }

    static async post(university) {
        university.currencyCodeId = Currencies.Usd;
        const response = await bookShopApiPrivateInstance.post(`${BookShopApiUrls.university}/`, university);
        return response;
    }
}