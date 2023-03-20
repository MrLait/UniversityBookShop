export const universitiesField = [
    {
        "id": 0,
        "name": "",
        "description": "",
        "faculties": [],
        "totalBookPrice": 0,
        "currencyCode": 0
    }
]

export const universityField =
{
    "id": 0,
    "name": "",
    "description": "",
    "faculties": [],
    "totalBookPrice": 0,
    "currencyCodeId": 0
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
    // {
    //     "id": 0,
    //     "bookId": 0,
    //     "facultyId": 0,
    //     "book": []
    // },
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