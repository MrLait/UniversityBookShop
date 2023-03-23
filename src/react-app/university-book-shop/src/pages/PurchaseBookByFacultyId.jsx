// @ts-nocheck
import React, { useEffect, useState } from 'react'
import BookApiService from '../API/BookApiService';
import Book from '../components/screens/Book/Book';
import styles from './PurchaseBookByFacultyId.module.css';

const PurchaseBookByFacultyId = () => {
    const [books, setBooks] = useState([]);
    const [isGetFilteredBook, setIsGetFilteredBook] = useState(false)

    useEffect(() => {
        getBooks();
    }, [])

    const getBooks = async () => {
        await BookApiService.getAll()
            .then((response) => {
                setBooks(response.data)
                setIsGetFilteredBook(true);
            })
    }

    return (
        <div>
            <div className={styles.wrap}>
                {books.map(b =>
                    <div key={b.id} className={styles.content} >
                        <Book
                            book={b}
                            isGetFilteredBook={isGetFilteredBook}
                            setIsGetFilteredBook={setIsGetFilteredBook}
                        />
                    </div>
                )}
            </div>
        </div>
    )
}

export default PurchaseBookByFacultyId
