// @ts-nocheck
import React, { useEffect, useState } from 'react';
import { useParams, useSearchParams, useNavigate } from 'react-router-dom';

import BookApiService from '../API/BookApiService';

import BooksAvailableForFacultyApiService from '../API/BooksAvailableForFaculty';
import PurchasedBookApiService from '../API/PurchasedBookApiService';
import BookList from '../components/screens/Book/BookList';
import { purchaseStatusConstants } from '../components/constants/purchaseStatusConstants';
import transition from '../unitls/transition';
import MyPagination from '../components/UI/pagination/MyPagination';
import { paginationField } from '../components/constants/initialStates';
import { routePathsNavigate } from '../router/routes';

import styles from './PurchaseBookByFacultyId.module.css';

const PurchaseBookByFacultyId = () => {
    const [searchParams] = useSearchParams();
    const pageIndex = searchParams.get('page');
    const navigate = useNavigate();
    const defaultPageIndex = parseInt(pageIndex || 1);

    const facultyId = parseInt(useParams().facultyId || 0);
    const [paginationData, setPaginationData] = useState(paginationField);
    const [books, setBooks] = useState([]);
    const [pageSize, setPageSize] = useState(4);

    useEffect(() => {
        getBooks(defaultPageIndex, pageSize);
    }, [defaultPageIndex]);

    const getBooks = async (defaultPageIndex, pageSize) => {
        await BookApiService.getBooksWithPurchaseStatusByFacultyIdWithPagination(facultyId, defaultPageIndex, pageSize)
            .then((response) => {
                const data = response.data.data.items;
                setBooks(data);
                setPaginationData(response.data.data);
            });
    };

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
                    updateBookStatus(bookId, purchaseStatusConstants.bookPurchasedByCurrentFaculty);
                }
                else {
                    updateBookErrorMessage(bookId, response.data.error.message);
                }
            });
    };

    const postAddBook = async (bookId, facultyId) => {
        await BooksAvailableForFacultyApiService.postAddBook(bookId, facultyId)
            .then(response => {
                var isSucceeded = response.data.isSucceeded;
                if (isSucceeded) {
                    updateBookStatus(bookId, purchaseStatusConstants.bookAddedByCurrentFaculty);
                }
            });
    };

    const getAvailableBook = async (bookId, facultyId) => {
        const availableBook =
            await BooksAvailableForFacultyApiService.getByFacultyIdBookId(facultyId, bookId)
                .then(response => {
                    var isSucceeded = response.data.isSucceeded;
                    if (isSucceeded) {
                        var availableBook = response.data.data;
                        return availableBook;
                    }
                });
        return availableBook;
    };

    const removeAvailableBook = async (bookId, facultyId) => {
        const availableBook = await getAvailableBook(bookId, facultyId);
        if (availableBook.bookId === bookId) {
            await BooksAvailableForFacultyApiService.deleteAvailableBook(availableBook.id)
                .then(response => {
                    var isSucceeded = response.data.isSucceeded;

                    if (isSucceeded) {
                        updateBookStatus(bookId, purchaseStatusConstants.bookAvailableForAdditionByCurrentFaculty);
                    } else {
                        var errorMessage = response.data.error.message;
                        updateBookErrorMessage(bookId, errorMessage);
                    }
                })
                .catch(error => {
                    var isSucceeded = error.response.data.isSucceeded;
                    const statusCode = error.response.data.error.statusCode;
                    if (!isSucceeded && statusCode === 404) {
                        updateBookErrorMessage(bookId, 'Book can\'t be removed.');
                    }
                });
        } else {
            updateBookErrorMessage(bookId, 'Available book for remove can\'t be founded.');
        }
    };

    const deletePurchasedBook = async (bookId, facultyId) => {
        await PurchasedBookApiService.deleteByFacultyIdAndBookId(facultyId, bookId)
            .then(response => {
                var isSucceeded = response.data.isSucceeded;
                if (isSucceeded) {
                    updateBookStatus(bookId, purchaseStatusConstants.bookAvailableForPurchase);
                } else {
                    updateBookErrorMessage(bookId, response.data.error.message);
                }
            })
            .catch(error => {
                updateBookErrorMessage(bookId, error.response.data.error.message);
            });
    };

    const buyBook = (bookId) => {
        postPurchaseBook(bookId, facultyId);
    };

    const addBook = (bookId) => {
        postAddBook(bookId, facultyId);
    };

    const removeBook = (bookId) => {
        removeAvailableBook(bookId, facultyId);
    };

    const deleteBook = (bookId) => {
        deletePurchasedBook(bookId, facultyId);
    };

    const changePage = (pageIndex) => {
        getBooks(pageIndex, pageSize);
        navigate(routePathsNavigate.SearchBookByFacultyIdPage(facultyId, pageIndex));
    };

    return (
        <div className={styles.block}>
            <div className={styles.inner}>
                {books
                    ?
                    <>
                        <div className={`${styles.contentHeaderTop} ${styles.textCenter}`}>
                            <div className={`${styles.headerTop}`}>
                                <h1 className={`${styles.textSizeBig} ${styles.upperCase}`}>
                                    Books
                                </h1>
                            </div>
                        </div>

                        <div className={styles.contentBody}>
                            <div className={styles.contentHeaderBot} >
                                <div className={styles.headerBotFlexLeft}>
                                    <strong>{paginationData.totalCount ?? 0} </strong>
                                    number of books available.
                                </div>
                                <div className={styles.headerBotFlexRight}>
                                    <MyPagination
                                        paginationData={paginationData}
                                        pageIndex={defaultPageIndex}
                                        changePage={changePage}
                                        className={styles.pagination}
                                    />
                                </div>
                            </div>
                            <BookList
                                pageSize={pageSize}
                                books={books}
                                buyBook={buyBook}
                                addBook={addBook}
                                removeBook={removeBook}
                                deleteBook={deleteBook}
                            />
                        </div>
                    </>
                    :
                    <div>There are no books.</div>
                }
            </div>
        </div >
    );
};

export default transition(PurchaseBookByFacultyId);