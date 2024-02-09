import axios from "axios";
import { BookShopApiUrls } from "./BookShopApiUrls";

const apiInstance = axios.create({
    baseURL: BookShopApiUrls.universityBookShopApiBaseURL
});

export default class FacultyApiService {

    static async getAll() {
        const response = await apiInstance.get(BookShopApiUrls.faculty)
        return response;
    }

    static async getFacultyByFacultyId(facultyId) {
        const response = await apiInstance.get(`${BookShopApiUrls.faculty}/${facultyId}`)
        return response;
    }

    static async getByUniversityIdWithPagination(universityId, pageSize, pageIndex) {
        const response = await apiInstance.get(`${BookShopApiUrls.facultiesByUniversityId}/${universityId}`,
            BookShopApiUrls.getPaginationParams(pageIndex, pageSize))
        return response;
    }

    static async delete(id) {
        const response = await apiInstance.delete(`${BookShopApiUrls.faculty}/${id}`)
        return response;
    }

    static async post(faculty) {
        const response = await apiInstance.post(`${BookShopApiUrls.faculty}/`, faculty)
        return response;
    }
}