import axios from "axios";
import { BookShopApiUrls } from "./BookShopApiUrls";

const apiInstance = axios.create({
    baseURL: BookShopApiUrls.universityBookShopApiBaseURL
});

export default class BooksAvailableForFacultyApiService {

    static async getAll() {
        const response = await apiInstance.get(`${BookShopApiUrls.booksAvailableForFaculty}/`)
        return response;
    }

    static async getByFacultyId(facultyId) {
        const response = await apiInstance.get(`${BookShopApiUrls.booksAvailableForFaculty}/${facultyId}`)
        return response;
    }

    static async getByFacultyIdBookId(facultyId, bookId) {
        const response = await apiInstance.get(`${BookShopApiUrls.booksAvailableForFaculty}/${facultyId}/${bookId}`)
        return response;
    }

    static async post(bookId, facultyId, universityId) {
        const response = await apiInstance.post(`${BookShopApiUrls.purchaseBookToFaculty}/`, { bookId, facultyId, universityId })
        return response;
    }

    static async delete(id) {
        const response = await apiInstance.delete(`${BookShopApiUrls.booksAvailableForFaculty}/${id}`)
        return response;
    }
}
