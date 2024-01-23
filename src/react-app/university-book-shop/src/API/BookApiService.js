import axios from "axios";
import { BookShopApiUrls } from "./BookShopApiUrls";

const apiInstance = axios.create({
    baseURL: BookShopApiUrls.universityBookShopApiBaseURL
});

export default class BookApiService {
    static async getAll() {
        const response = await apiInstance.get(`${BookShopApiUrls.book}/`)
        return response;
    }
}
