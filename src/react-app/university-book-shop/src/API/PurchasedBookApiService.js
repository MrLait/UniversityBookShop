import axios from "axios";
import { BookShopApiUrls } from "./BookShopApiUrls";

const apiInstance = axios.create({
    baseURL: BookShopApiUrls.universityBookShopApiBaseURL
});

export default class PurchasedBookApiService {
    static async getAll() {
        const response = await apiInstance.get(`${BookShopApiUrls.purchasedBookFaculty}/`)
        return response;
    }

    static async getByFacultyId(facultyId) {
        const response = await apiInstance.get(`${BookShopApiUrls.purchasedBookFaculty}/${facultyId}`)
        return response;
    }

    // static async delete(id) {
    //     const response = await apiInstance.delete(`University/${id}`)
    //     return response;
    // }

    // static async post(university) {
    //     const response = await apiInstance.post('University/', university)
    //     return response;
    // }
}