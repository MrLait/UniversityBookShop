import axios from 'axios';

import { BookShopApiUrls, bookShopApiPrivateInstance, bookShopApiInstance } from './BookShopApiUrls';

export default class FacultyApiService {

    static async getAll() {
        const response = await bookShopApiInstance.get(BookShopApiUrls.faculty);
        return response;
    }

    static async getFacultyByFacultyId(facultyId) {
        const response = await bookShopApiInstance.get(`${BookShopApiUrls.faculty}/${facultyId}`);
        const { data } = response;
        return {
            faculty: data.data,
            validationError: data.error,
            validationIsSucceeded: data.isSucceeded,
        };
    }

    static async getFacultyByFacultyIdWithPagination(facultyId, pageIndex, pageSize) {
        const response = await bookShopApiInstance.get(`${BookShopApiUrls.faculty}/${facultyId}`,
            BookShopApiUrls.getPaginationParams(pageIndex, pageSize));
        return response;
    }

    static async getByUniversityIdWithPagination(universityId, pageSize, pageIndex) {
        const response = await bookShopApiInstance.get(`${BookShopApiUrls.facultiesByUniversityId}/${universityId}`,
            BookShopApiUrls.getPaginationParams(pageIndex, pageSize));
        return response;
    }

    static async deleteFacultyByFacultyId(facultyId) {
        const response = await bookShopApiPrivateInstance.delete(`${BookShopApiUrls.faculty}/${facultyId}`);
        return response;
    }

    static async post(faculty) {
        const response = await bookShopApiPrivateInstance.post(`${BookShopApiUrls.faculty}/`, faculty);
        return response;
    }
}