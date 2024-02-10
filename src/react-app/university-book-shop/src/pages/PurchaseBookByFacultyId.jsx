// @ts-nocheck
import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import BookApiService from '../API/BookApiService';
import Book from '../components/screens/Book/BookCard';
import styles from './PurchaseBookByFacultyId.module.css';
import BooksAvailableForFacultyApiService from '../API/BooksAvailableForFaculty';
import BookList from '../components/screens/Book/BookList'
import PurchasedBookApiService from '../API/PurchasedBookApiService';
import { purchaseStatusConstants } from '../components/constants/purchaseStatusConstants'

const PurchaseBookByFacultyId = () => {
    const facultyId = parseInt(useParams().facultyId || 0);
    const [books, setBooks] = useState([]);
    const [isGetFilteredBook, setIsGetFilteredBook] = useState(false)
    const [booksAvailableForFaculty, setBooksAvailableForFaculty] = useState([]);

    useEffect(() => {
        getBooks();
    }, [])

    const getBooks = async () => {
        await BookApiService.getBooksWithPurchaseStatusByFacultyIdWithPagination(facultyId)
            .then((response) => {
                const data = response.data.data.items;
                setBooks(data)
            })
    }

    const postPurchaseBook = async (bookId, facultyId) => {
        await PurchasedBookApiService.postPurchaseBookForFaculty(bookId, facultyId)
            .then(response => {
                var isSucceeded = response.data.isSucceeded;
                if (isSucceeded) {
                    const updateBookStatus = books.map(book => {
                        if (bookId === book.id) {
                            return {
                                ...book,
                                purchaseStatus: purchaseStatusConstants.bookPurchasedByCurrentFaculty
                            }
                        }
                        return book;
                    })
                    setBooks(updateBookStatus)
                }
            })
    }

    const postAddBook = async (bookId, facultyId) => {
        await BooksAvailableForFacultyApiService.postAddBook(bookId, facultyId)
            .then(response => {
                var isSucceeded = response.data.isSucceeded;
                if (isSucceeded) {
                    const updateBookStatus = books.map(book => {
                        if (bookId === book.id) {
                            return {
                                ...book,
                                purchaseStatus: purchaseStatusConstants.bookAddedByCurrentFaculty
                            }
                        }
                        return book;
                    })
                    setBooks(updateBookStatus)
                }
            })
    }

    const buyBook = (bookId) => {
        postPurchaseBook(bookId, facultyId)
    }

    const addBook = (bookId) => {
        postAddBook(bookId, facultyId)
    }

    return (
        <div className={styles.block}>
            {books
                ?
                <>
                    <div className={styles.inner}>
                        <div className={`${styles.contentHeaderTop} ${styles.textCenter}`}>
                            <div className={styles.headerTop}>
                                <h1 className={`${styles.headerTopText} ${styles.upperCase}`}>
                                    Books
                                </h1>
                            </div>
                        </div>
                        <div className={styles.contentHeaderBot} >
                            <div className={styles.headerBotFlexLeft}>
                                <strong>{books?.length} </strong>
                                number of books available.
                            </div>
                        </div>
                    </div>
                    <div className={styles.contentBody}>
                        <div className={styles.inner}>
                            <BookList
                                books={books}
                                buyBook={buyBook}
                                addBook={addBook}
                            />
                        </div>
                    </div>
                </>
                :
                <div className={styles.inner}>
                    <div>There are no books.</div>
                </div>
            }
        </div >
    )
}

export default PurchaseBookByFacultyId
