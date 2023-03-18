// @ts-nocheck
import React, { useEffect, useState } from 'react'
import BookApiService from '../API/BookApiService';
import Book from '../components/screens/Book/Book';
import styles from './PurchaseBookByFacultyId.module.css';

const PurchaseBookByFacultyId = () => {
    const [books, setBooks] = useState([]);
    useEffect(() => {
        getBooks();
    }, [])
    const getBooks = async () => {
        const response = await BookApiService.getAll()
        setBooks(response.data);
    }

    // const [purchasedBooks, setPurchasedBooks] = useState(purchasedBooksField);
    // console.log('PurchasedBooks: ', purchasedBooks);
    // const getPurchasedBooks = async () => {
    //     const response = await PurchasedBookApiService.getByFacultyId(facultyId)
    //     setPurchasedBooks(response.data)
    // }
    // useEffect(() => {
    //     if (isVisible) {
    //         getPurchasedBooks()
    //     }
    //     else {
    //         setPurchasedBooks(purchasedBooksField)
    //     }
    // }, [isVisible])
    return (
        <div>
            <div className={styles.wrap}>
                {books.map(b =>
                    <div key={b.id} className={styles.content} >
                        <Book book={b} />
                    </div>)}
            </div>
        </div>
    )
}

export default PurchaseBookByFacultyId
