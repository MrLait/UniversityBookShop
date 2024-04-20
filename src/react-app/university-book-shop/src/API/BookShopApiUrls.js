export const BookShopApiUrls = {
    universityBookShopApiBaseURL: process.env.REACT_APP_BASE_URL === 'useNginx' ? '/api/' : 'http://localhost:7265/api/',
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
    authLoginByUserNameAndPasswordUrl: 'Auth/login/ByUsernameAndPassword',
};

// const AuthStr = 'Bearer '.concat(localStorage.getItem('accessToken'));
// export const headerWithAuthStr = { headers: { Authorization: AuthStr } };

// http://localhost:7265/api/Auth/login/ByUsernameAndPassword
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

