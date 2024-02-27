// @ts-nocheck
import React, { useCallback, useEffect, useState } from 'react';
import { useParams, useSearchParams, useNavigate } from 'react-router-dom';

import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query';

import BookApiService from '../../API/BookApiService';

import BooksAvailableForFacultyApiService from '../../API/BooksAvailableForFaculty';
import PurchasedBookApiService from '../../API/PurchasedBookApiService';
import BookList from '../../components/screens/PurchasedBooksByFacultyId/BookList/BookList';
import { purchaseStatusConstants } from '../../components/constants/purchaseStatusConstants';
import transition from '../../unitls/transition';
import { paginationField } from '../../components/constants/initialStates';
import { routePathsNavigate } from '../../router/routes';

import PurchaseBookHeaderSection from '../../components/screens/PurchasedBooksByFacultyId/PurchaseBookHeaderSection';
import ContentWithPaginationSection from '../../components/screens/PurchasedBooksByFacultyId/ContentWithPaginationSection';

import styles from './PurchaseBookByFacultyId.module.css';

const getBooks = async (facultyId, defaultPageIndex, pageSize) => {
    const { data } = await BookApiService.getBooksWithPurchaseStatusByFacultyIdWithPagination(facultyId, defaultPageIndex, pageSize);
    return {
        books: data.data.items,
        validationError: data.error,
        validationIsSucceeded: data.isSucceeded,
        paginationData: (({ items, ...paginationData }) => paginationData)(data.data),
    };
};

const postAddBook = async (bookId, facultyId) => {
    await BooksAvailableForFacultyApiService.postAddBook(bookId, facultyId);
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
        await BooksAvailableForFacultyApiService.deleteAvailableBook(availableBook.id);
    }
};


// при getAvailableBook нужно делать invalidateQuery https://www.youtube.com/watch?v=AAMBoENvfnE&ab_channel=CandDev
const PurchaseBookByFacultyId = () => {
    const [searchParams] = useSearchParams();
    const navigate = useNavigate();
    const [defaultPageIndex, setDefaultPageIndex] = useState(parseInt(searchParams.get('page') || 1));

    const facultyId = parseInt(useParams().facultyId || 0);
    const [paginationData, setPaginationData] = useState(paginationField);
    const [books, setBooks] = useState([]);
    const pageSize = 4;
    const queryClient = useQueryClient();

    const { data, isSuccess } = useQuery({
        queryKey: ['getBooks', defaultPageIndex, books],
        queryFn: async () => getBooks(facultyId, defaultPageIndex, pageSize),
        staleTime: Infinity,
    },);

    // const postAddBook = async (bookId, facultyId) => {
    //     await BooksAvailableForFacultyApiService.postAddBook(bookId, facultyId)
    //         .then(response => {
    //             var isSucceeded = response.data.isSucceeded;
    //             if (isSucceeded) {
    //                 updateBookStatus(bookId, purchaseStatusConstants.bookAddedByCurrentFaculty);
    //             }
    //         });
    // };

    const addBookMutation = useMutation({
        mutationFn: (bookId) => postAddBook(bookId, facultyId),
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ['getBooks'] });
        },
    });

    const removeBookMutation = useMutation({
        mutationFn: (bookId) => removeAvailableBook(bookId, facultyId),
        onSuccess: () => {
            queryClient.invalidateQueries({ queryKey: ['getBooks'] });
        },
    });
    console.log(books);


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



    // const getAvailableBook = async (bookId, facultyId) => {
    //     const availableBook =
    //         await BooksAvailableForFacultyApiService.getByFacultyIdBookId(facultyId, bookId)
    //             .then(response => {
    //                 var isSucceeded = response.data.isSucceeded;
    //                 if (isSucceeded) {
    //                     var availableBook = response.data.data;
    //                     return availableBook;
    //                 }
    //             });
    //     return availableBook;
    // };

    // const removeAvailableBook = async (bookId, facultyId) => {
    //     const availableBook = await getAvailableBook(bookId, facultyId);
    //     if (availableBook.bookId === bookId) {
    //         await BooksAvailableForFacultyApiService.deleteAvailableBook(availableBook.id)
    //             .then(response => {
    //                 var isSucceeded = response.data.isSucceeded;

    //                 if (isSucceeded) {
    //                     updateBookStatus(bookId, purchaseStatusConstants.bookAvailableForAdditionByCurrentFaculty);
    //                 } else {
    //                     var errorMessage = response.data.error.message;
    //                     updateBookErrorMessage(bookId, errorMessage);
    //                 }
    //             })
    //             .catch(error => {
    //                 var isSucceeded = error.response.data.isSucceeded;
    //                 const statusCode = error.response.data.error.statusCode;
    //                 if (!isSucceeded && statusCode === 404) {
    //                     updateBookErrorMessage(bookId, 'Book can\'t be removed.');
    //                 }
    //             });
    //     } else {
    //         updateBookErrorMessage(bookId, 'Available book for remove can\'t be founded.');
    //     }
    // };

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
        // postAddBook(bookId, facultyId);
        addBookMutation.mutate(bookId, facultyId);
    };

    const removeBook = (bookId) => {
        // removeAvailableBook(bookId, facultyId);
        removeBookMutation.mutate(bookId, facultyId);
    };

    const deleteBook = (bookId) => {
        deletePurchasedBook(bookId, facultyId);
    };

    // useEffect(() => {
    //     getBooks(facultyId, defaultPageIndex, pageSize);
    // }, [defaultPageIndex, facultyId]);

    const changePage = useCallback((pageIndex) => {
        navigate(routePathsNavigate.SearchBookByFacultyIdPage(facultyId, pageIndex));
        setDefaultPageIndex(pageIndex);
    }, [facultyId, navigate]);

    return (
        <div className={styles.block}>
            <div className={styles.inner}>
                {isSuccess ?? data.books
                    ?
                    <>
                        <PurchaseBookHeaderSection />
                        <div className={styles.contentBody}>
                            <>
                                <ContentWithPaginationSection
                                    paginationData={data.paginationData}
                                    defaultPageIndex={defaultPageIndex}
                                    changePage={changePage}
                                />
                                <BookList
                                    pageSize={data.paginationData.pageSize}
                                    books={data.books}
                                    buyBook={buyBook}
                                    addBook={addBook}
                                    removeBook={removeBook}
                                    deleteBook={deleteBook}
                                />
                            </>
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
