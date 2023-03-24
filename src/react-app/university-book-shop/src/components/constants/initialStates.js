export const universitiesField = [
    {
        "id": 0,
        "name": "",
        "description": "",
        "faculties": [],
        "totalBookPrice": 0,
        "currencyCode": {
            "id": 0,
            "code": ""
        },
        "facultyCount": 0,
        "bookCount": 0,
    }
]

export const universityField =
{
    "id": 0,
    "name": "",
    "description": "",
    "faculties": [],
    "totalBookPrice": 0,
    "currencyCode": {
        "id": 0,
        "code": ""
    },
    "bookCount": 0,
    "facultyCount": 0,
}

export const Currencies = {
    Usd: 1,
    Euro: 2
}

export const currencyCodeField = {
    currencyCode: {
        "id": 0,
        "code": ""
    }
}

export const purchasedBooksField = [
    {
        "id": 0,
        "bookId": 0,
        "facultyId": 0,
        "book": {
            "id": 0,
            "isbn": "",
            "name": "",
            "author": "",
            "price": 0,
            "currencyCode": {
                "id": 0,
                "code": ""
            }
        }
    }
]

export const booksAvailableForFacultyField = [
    {
        "id": 0,
        "bookId": 0,
        "facultyId": 0,
        "isPurchased": false,
        "booksPurchasedByUniversityId": 0,
        "book": {
            "id": 0,
            "isbn": "",
            "name": "",
            "author": "",
            "price": 0,
            "currencyCode": {
                "id": 0,
                "code": ""
            }
        }
    }
]

export const purchasedBookField = {
    "id": 0,
    "bookId": 0,
    "facultyId": 0,
    "isPurchased": false,
    "booksPurchasedByUniversityId": 0,
    "book": []
}

export const facultyField = {
    "id": 0,
    "name": "",
    "universityId": 0
}

export const paginationField = {
    "PageIndex": 0,
    "TotalCount": 0,
    "TotalPages": 0,
    "IsPrevious": false,
    "IsNext": false
}

export const paginationHeader = 'x-pagination';