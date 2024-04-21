// @ts-nocheck
import axios from 'axios';

import { BookShopApiUrls, bookShopApiInstance } from './BookShopApiUrls';


export default class BookApiService {

    static async getBooksWithPurchaseStatusByFacultyIdWithPagination(facultyId, pageIndex, pageSize) {
        const response = await bookShopApiInstance.get(`${BookShopApiUrls.book}/${BookShopApiUrls.faculty}/${facultyId}`,
            BookShopApiUrls.getPaginationParams(pageIndex, pageSize),
        );
        const { data } = response;
        return {
            books: data.data.items,
            validationError: data.error,
            validationIsSucceeded: data.isSucceeded,
            paginationData: (({ items, ...paginationData }) => paginationData)(data.data),
        };
    }
}
