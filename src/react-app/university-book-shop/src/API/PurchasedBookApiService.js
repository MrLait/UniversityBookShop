import { BookShopApiUrls, bookShopApiPrivateInstance, bookShopApiInstance } from './BookShopApiUrls';

export default class PurchasedBookApiService {
    static async getAll() {
        const response = await bookShopApiInstance.get(`${BookShopApiUrls.purchasedBookFaculty}/`);
        return response;
    }

    static async getByFacultyId(facultyId) {
        const response = await bookShopApiInstance.get(`${BookShopApiUrls.purchasedBookByFacultyId}/${facultyId}`);
        return response;
    }

    static async getByUniversityId(universityId) {
        const response = await bookShopApiInstance.get(`${BookShopApiUrls.purchasedBookByUniversityId}/${universityId}`);
        return response;
    }

    static async postPurchaseBookForFaculty(bookId, facultyId) {
        const response = await bookShopApiPrivateInstance.post(`${BookShopApiUrls.purchasedBookFaculty}/`, { bookId, facultyId });
        return response;
    }

    static async delete(id) {
        const response = await bookShopApiPrivateInstance.delete(`${BookShopApiUrls.purchasedBookFaculty}/${id}`);
        return response;
    }

    static async deleteByFacultyIdAndBookId(facultyId, bookId) {
        const response = await bookShopApiPrivateInstance.delete(`${BookShopApiUrls.purchasedBookFaculty}/faculty/${facultyId}/book/${bookId}`);
        return response;
    }


}