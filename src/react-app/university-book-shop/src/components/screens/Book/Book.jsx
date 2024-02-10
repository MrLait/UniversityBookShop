// @ts-nocheck
import React from 'react'
import AddBook from './AddBook';
import styles from './Book.module.css';
import { useLocation, useParams } from 'react-router-dom';
import BooksAvailableForFacultyApiService from '../../../API/BooksAvailableForFaculty';
import BooksPurchasedByUniversityApiService from '../../../API/BooksPurchasedByUniversity';
import { useState } from 'react';
import { useEffect } from 'react';
import { purchasedBookField } from '../../constants/initialStates'
// const Book = ({ book, purchasedBooksByFacultyId, setPurchasedBooksByFacultyId }) => {

const Book = ({ book, isGetFilteredBook, setIsGetFilteredBook }) => {
    const facultyId = parseInt(useParams().facultyId || 0);
    // const { universityId } = useLocation().state
    // const [purchasedBook, setPurchasedBook] = useState(purchasedBookField);
    // const [isBookAtUniversity, setIsBookAtUniversity] = useState(false)

    // const getPurchasedBooks = async () => {
    //     await BooksAvailableForFacultyApiService.getByFacultyIdBookId(facultyId, book.id)
    //         .then((response) => {
    //             if (response.status == 200) {
    //                 const isSucceeded = response.data.isSucceeded
    //                 const data = response.data.data;
    //                 const error = response.data.error
    //                 if (isSucceeded) {
    //                     setPurchasedBook(data.items)
    //                     setIsBookAtUniversity(false);
    //                 }

    //                 if (!isSucceeded && error.statusCode === 404) {
    //                     BooksPurchasedByUniversityApiService.getIsBookAtUniversity(book.id, universityId)
    //                         .then((isBookAtUniversityResponse) => {
    //                             setIsBookAtUniversity(isBookAtUniversityResponse.data);
    //                             setPurchasedBook(response.data)
    //                         })
    //                 }
    //             }

    //         })
    // }
    // useEffect(() => {
    //     if (isGetFilteredBook) {
    //         getPurchasedBooks()
    //     }
    // }, [])

    const addBook = async (bookId) => {
        // await BooksAvailableForFacultyApiService.post(bookId, facultyId, universityId)
        //     .then(() => {
        //         getPurchasedBooks()
        //     })
    }

    return (
        <>
            <>
                <div className={styles.myBook}>
                    <div>
                        <h1>
                            {book.name}
                        </h1>
                    </div>
                    <div>
                        by&nbsp;
                        <span>{book.author} (Author)</span>
                    </div>
                    <div>
                        <hr />
                        {book.isPurchased === true && (
                            <>
                                <div>Book is purchased</div>
                                <div> Price : {book.price} {book.currencyCode.code}</div>
                                <hr />
                                <div>Purchased</div>
                            </>
                        )}

                        {book.isPurchased === false && (
                            <div>
                                <div>Price : FREE</div>
                                <hr />
                                <div>At University</div>
                                <AddBook
                                    book={book}
                                    addBook={addBook}
                                />
                            </div>
                        )}

                        {book.isPurchased === undefined && (
                            <>
                                <div>Book purchase status is unknown</div>
                                <div> Price : {book.price} {book.currencyCode.code}</div>
                                <hr />
                                <div>
                                    <AddBook
                                        book={book}
                                        addBook={addBook}
                                    />
                                </div>
                            </>
                        )}
                    </div>
                </div >
            </>
            <>

            </>
        </>
    )
}

export default Book;