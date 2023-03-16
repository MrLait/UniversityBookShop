import axios from "axios";
import { BookShopApiUrls } from "./BookShopApiUrls";

const apiInstance = axios.create({
    baseURL: BookShopApiUrls.universityBookShopApiBaseURL
});

export default class UniversityApi {
    static async getAll() {
        const response = await apiInstance.get(BookShopApiUrls.university)
        return response;
    }

    static async delete(id) {
        const response = await apiInstance.delete(`${BookShopApiUrls.university}/${id}`)
        return response;
    }

    static async post(university) {
        const response = await apiInstance.post(`${BookShopApiUrls.university}/`, university)
        return response;
    }
}