// @ts-nocheck
import React, { useEffect, useState } from 'react'
import BookApiService from '../API/BookApiService';
import Book from '../components/screens/Book/Book';
import styles from './PurchaseBookByFacultyId.module.css';
import { useParams } from 'react-router-dom';
import PurchasedBookApiService from '../API/PurchasedBookApiService';

const PurchaseBookByFacultyId = () => {
    const [books, setBooks] = useState([]);
    const [purchasedBooks, setPurchasedBooks] = useState([]);
    const { faculty_id } = useParams()

    useEffect(() => {
        getBooks();
        getPurchasedBooks();
    }, [])

    console.log(books);
    console.log(purchasedBooks);
    const getBooks = async () => {
        const response = await BookApiService.getAll()
        setBooks(response.data);
    }

    const getPurchasedBooks = async () => {
        const response = await PurchasedBookApiService.getByFacultyId(faculty_id)
        setPurchasedBooks(response.data)
    }

    return (
        <div>
            <div className={styles.wrap}>
                {books.map(b =>
                    <div key={b.id} className={styles.content} >
                        <Book
                            book={b}
                            purchasedBooks={purchasedBooks}
                            setPurchasedBooks={setPurchasedBooks}
                        />
                    </div>)}
            </div>
        </div>
    )
}

export default PurchaseBookByFacultyId
