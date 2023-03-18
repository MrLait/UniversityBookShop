import React, { useEffect, useState } from 'react'
import { useLocation, useParams } from 'react-router-dom';
import BookApiService from '../API/BookApiService';
import PurchasedBookApiService from '../API/PurchasedBookApiService';
import Book from '../components/screens/Book/Book';

const PurchaseBookByFacultyId = () => {
    const [books, setBooks] = useState([]);
    useEffect(() => {
        getBooks();
    }, [])
    const getBooks = async () => {
        const response = await BookApiService.getAll()
        setBooks(response.data);
    }


    return (
        <div>
            <div>
                {books.map(b =>
                    <div key={b.id} >
                        <Book book={b} />
                    </div>)}
            </div>
        </div>
    )
}

export default PurchaseBookByFacultyId
