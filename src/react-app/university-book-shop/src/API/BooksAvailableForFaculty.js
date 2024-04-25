import { BookShopApiUrls, bookShopApiPrivateInstance, bookShopApiInstance } from './BookShopApiUrls';

export default class BooksAvailableForFacultyApiService {

    static async getAll() {
        const response = await bookShopApiInstance.get(`${BookShopApiUrls.booksAvailableForFaculty}/`);
        return response;
    }

    static async getByFacultyId(facultyId) {
        const response = await bookShopApiInstance.get(`${BookShopApiUrls.booksAvailableForFaculty}/${facultyId}`);
        return response;
    }

    static async getByFacultyIdWithPagination(facultyId, pageIndex, pageSize) {
        const response = await bookShopApiInstance.get(`${BookShopApiUrls.booksAvailableForFaculty}/${facultyId}`,
            BookShopApiUrls.getPaginationParams(pageIndex, pageSize));
        const { data } = response;
        return {
            availableBooks: data.data.items,
            validationError: data.error,
            validationIsSucceeded: data.isSucceeded,
            paginationData: (({ items, ...paginationData }) => paginationData)(data.data),
        };
    }

    static async getByFacultyIdBookId(facultyId, bookId) {
        const response = await bookShopApiInstance.get(`${BookShopApiUrls.booksAvailableForFaculty}/${facultyId}/${bookId}`);
        const { data } = response;
        return {
            availableBook: data.data,
            validationError: data.error,
            validationIsSucceeded: data.isSucceeded,
        };
    }

    static async postAddBook(bookId, facultyId) {
        const response = await bookShopApiPrivateInstance.post(`${BookShopApiUrls.addBooksAvailableForFaculty}/`, { bookId, facultyId });
        return response;
    }

    static async deleteAvailableBook(bookId) {
        const response = await bookShopApiPrivateInstance.delete(`${BookShopApiUrls.booksAvailableForFaculty}/${bookId}`);
        return response;
    }
}
