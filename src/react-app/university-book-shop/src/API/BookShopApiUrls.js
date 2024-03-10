export const BookShopApiUrls = {
    // universityBookShopApiBaseURL: 'https://localhost:7265/api/',
    universityBookShopApiBaseURL: 'api/',
    university: 'University',
    purchasedBookFaculty: 'PurchasedBookFaculty',
    purchasedBookByFacultyId: 'PurchasedBookFaculty/Faculty',
    purchasedBookByUniversityId: 'PurchasedBookFaculty/University',
    book: 'Book',
    booksAvailableForFaculty: 'BooksAvailableForFaculty',
    addBooksAvailableForFaculty: 'BooksAvailableForFaculty/add',
    booksPurchasedByUniversity: 'BooksPurchasedByUniversity',
    faculty: 'Faculty',
    facultiesByUniversityId: 'Faculty/university',
    getPaginationParams,
};

function getPaginationParams(pageIndex, pageSize) {
    if (pageIndex < 0) {
        throw new Error('pageIndex should be a non-negative number');
    }
    if (pageSize <= 0) {
        throw new Error('pageSize should be a positive number');
    }

    return {
        params: {
            pageIndex,
            pageSize,
        },
    };
}

