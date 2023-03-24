export const BookShopApiUrls = {
    universityBookShopApiBaseURL: 'https://localhost:7265/api/',
    university: 'University',
    paginatedUniversities: (pageIndex, pageSize) => `${BookShopApiUrls.university}?PageIndex=${pageIndex}&PageSize=${pageSize}`,
    purchasedBookFaculty: 'PurchasedBookFaculty',
    purchasedBookByFacultyId: 'PurchasedBookFaculty/Faculty',
    purchasedBookByUniversityId: 'PurchasedBookFaculty/University',
    book: 'Book',
    booksAvailableForFaculty: 'BooksAvailableForFaculty',
    purchaseBookToFaculty: 'BooksAvailableForFaculty/purchase',
    booksPurchasedByUniversity: 'BooksPurchasedByUniversity',
    faculty: 'Faculty',
}

