import axios from 'axios';

import { BookShopApiUrls } from './BookShopApiUrls';

const apiInstance = axios.create({
    baseURL: BookShopApiUrls.universityBookShopApiBaseURL,
});

export default class FacultyApiService {

    static async getAll() {
        const response = await apiInstance.get(BookShopApiUrls.faculty);
        return response;
    }

    static async getFacultyByFacultyId(facultyId) {
        const response = await apiInstance.get(`${BookShopApiUrls.faculty}/${facultyId}`);
        const { data } = response;
        return {
            faculty: data.data,
            validationError: data.error,
            validationIsSucceeded: data.isSucceeded,
        };
    }

    static async getFacultyByFacultyIdWithPagination(facultyId, pageIndex, pageSize) {
        const response = await apiInstance.get(`${BookShopApiUrls.faculty}/${facultyId}`,
            BookShopApiUrls.getPaginationParams(pageIndex, pageSize));
        return response;
    }

    static async getByUniversityIdWithPagination(universityId, pageSize, pageIndex) {
        const response = await apiInstance.get(`${BookShopApiUrls.facultiesByUniversityId}/${universityId}`,
            BookShopApiUrls.getPaginationParams(pageIndex, pageSize));
        return response;
    }

    static async deleteFacultyByFacultyId(facultyId) {
        const response = await apiInstance.delete(`${BookShopApiUrls.faculty}/${facultyId}`);
        return response;
    }

    static async post(faculty) {
        const response = await apiInstance.post(`${BookShopApiUrls.faculty}/`, faculty);
        return response;
    }
}