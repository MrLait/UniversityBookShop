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
import { responsivePropType } from 'react-bootstrap/esm/createUtilityClasses';

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

    const updateBookStatus = (bookId, purchaseStatus) => {
        const updatedBooks = books.map(book => {
            if (bookId === book.id) {
                return {
                    ...book,
                    purchaseStatus,
                };
            }
            return book;
        });
        setBooks(updatedBooks);
    };

    const updateBookErrorMessage = (bookId, errorMessage) => {
        const updatedBooks = books.map(book => {
            if (bookId === book.id) {
                return {
                    ...book,
                    errorMessage,
                };
            }
            return book;
        });
        setBooks(updatedBooks);
    };

    const postPurchaseBook = async (bookId, facultyId) => {
        await PurchasedBookApiService.postPurchaseBookForFaculty(bookId, facultyId)
            .then(response => {
                var isSucceeded = response.data.isSucceeded;
                if (isSucceeded) {
                    updateBookStatus(bookId, purchaseStatusConstants.bookPurchasedByCurrentFaculty)
                }
            })
    }

    const postAddBook = async (bookId, facultyId) => {
        await BooksAvailableForFacultyApiService.postAddBook(bookId, facultyId)
            .then(response => {
                var isSucceeded = response.data.isSucceeded;
                if (isSucceeded) {
                    updateBookStatus(bookId, purchaseStatusConstants.bookAddedByCurrentFaculty)
                }
            })
    }

    const getAvailableBook = async (bookId, facultyId) => {
        const availableBook =
            await BooksAvailableForFacultyApiService.getByFacultyIdBookId(facultyId, bookId)
                .then(response => {
                    var isSucceeded = response.data.isSucceeded;
                    if (isSucceeded) {
                        var availableBook = response.data.data.items[0]
                        return availableBook
                    }
                })
        return availableBook
    }

    const deleteAvailableBook = async (bookId, facultyId) => {
        const availableBook = await getAvailableBook(bookId, facultyId);
        if (availableBook.bookId === bookId) {
            await BooksAvailableForFacultyApiService.deleteAvailableBook(availableBook.id)
                .then(response => {
                    var isSucceeded = response.data.isSucceeded;
                    if (isSucceeded) {
                        updateBookStatus(bookId, purchaseStatusConstants.bookAvailableForAdditionByCurrentFaculty)
                    }
                })
                .catch(error => {
                    var isSucceeded = error.response.data.isSucceeded;
                    const statusCode = error.response.data.error.statusCode;
                    if (!isSucceeded && statusCode === 404) {
                        updateBookErrorMessage(bookId, "Book can't be removed.")
                    }
                })
        } else {
            updateBookErrorMessage(bookId, "Available book for remove can't be founded.")
        }
    }

    const buyBook = (bookId) => {
        postPurchaseBook(bookId, facultyId)
    }

    const addBook = (bookId) => {
        postAddBook(bookId, facultyId)
    }

    const removeBook = (bookId) => {
        deleteAvailableBook(bookId, facultyId)
    }

    const deleteBook = (bookId) => {
        // deletePurchasedBook(bookId, facultyId)
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
                                removeBook={removeBook}
                                deleteBook={deleteBook}
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
