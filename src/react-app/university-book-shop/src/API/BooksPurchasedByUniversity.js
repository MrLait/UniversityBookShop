import axios from "axios";
import { BookShopApiUrls } from "./BookShopApiUrls";

const apiInstance = axios.create({
    baseURL: BookShopApiUrls.universityBookShopApiBaseURL
});

export default class BooksPurchasedByUniversityApiService {
    static async getAll() {
        const response = await apiInstance.get(`${BookShopApiUrls.booksPurchasedByUniversity}/`)
        return response;
    }
}
