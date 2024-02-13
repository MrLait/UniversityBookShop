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

    static async getByFacultyIdWithPagination(facultyId, pageIndex, pageSize) {
        const response = await apiInstance.get(`${BookShopApiUrls.booksAvailableForFaculty}/${facultyId}`,
            BookShopApiUrls.getPaginationParams(pageIndex, pageSize))
        return response;
    }

    static async getByFacultyIdBookId(facultyId, bookId) {
        const response = await apiInstance.get(`${BookShopApiUrls.booksAvailableForFaculty}/${facultyId}/${bookId}`)
        return response;
    }

    static async postAddBook(bookId, facultyId) {
        const response = await apiInstance.post(`${BookShopApiUrls.addBooksAvailableForFaculty}/`, { bookId, facultyId })
        return response;
    }

    static async deleteAvailableBook(bookId) {
        const response = await apiInstance.delete(`${BookShopApiUrls.booksAvailableForFaculty}/${bookId}`)
        return response;
    }
}
