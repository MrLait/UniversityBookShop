import axios from "axios";

const universityBookShopApiBaseURL = 'https://localhost:7265/api/';

const universityBookShopApiInstance = axios.create({
    baseURL: universityBookShopApiBaseURL
});

export default class UniversityApi {
    static async getAll() {
        const response = await universityBookShopApiInstance.get('University')
        return response;
    }

    static async delete(id) {
        const response = await universityBookShopApiInstance.delete(`University/${id}`)
        return response;
    }

    static async post(university) {
        const response = await universityBookShopApiInstance.post('University/', university)
        return response;
    }
}