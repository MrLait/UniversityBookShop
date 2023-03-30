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

    static async getByUniversityId(universityId) {
        const response = await apiInstance.get(`${BookShopApiUrls.faculty}/${universityId}`)
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