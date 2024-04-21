import axios from 'axios';

export const BookShopApiUrls = {
    baseURL: process.env.REACT_APP_BASE_URL === 'useNginx' ? '/api/' : 'http://localhost:7265/api/',
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

export const bookShopApiInstance = axios.create({
    baseURL: BookShopApiUrls.baseURL,
});

export const bookShopApiPrivateInstance = axios.create({
    baseURL: BookShopApiUrls.baseURL,
});

// const isRememberMe = `${localStorage.getItem('isRememberMe')}`;

// if (isRememberMe === 'true') {
bookShopApiPrivateInstance.interceptors.request.use(config => {
    const accessToken = `${localStorage.getItem('accessToken')}`;
    config.headers.Authorization = `Bearer ${accessToken}`;
    return config;
});
// }

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

