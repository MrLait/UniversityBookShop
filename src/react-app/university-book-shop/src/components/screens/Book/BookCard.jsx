// @ts-nocheck
import React from 'react'
import AddBook from './AddBook';
import styles from './BookCard.module.css';
import { useLocation, useParams } from 'react-router-dom';
import PurchasedBookApiService from '../../../API/PurchasedBookApiService';
import BooksPurchasedByUniversityApiService from '../../../API/BooksPurchasedByUniversity';
import { useState } from 'react';
import { useEffect } from 'react';
import { purchasedBookField } from '../../constants/initialStates'
import { purchaseStatusConstants } from '../../constants/purchaseStatusConstants'
import MyButton from '../../UI/button/MyButton'
// const Book = ({ book, purchasedBooksByFacultyId, setPurchasedBooksByFacultyId }) => {

const BookCard = ({ book, buyBook, addBook }) => {
    const facultyId = parseInt(useParams().facultyId || 0);
    return (
        <>
            <div className={styles.bookCard}>
                <div className={styles.header}>
                    <div className={styles.headerTop}>
                        <div className={styles.headerLeft}>
                            <strong>
                                {book.name}
                            </strong>
                        </div>
                        <div className={styles.headerRight}>
                            {/* <DeletePurchasedBook
                                id={purchasedBookId}
                                deleteClick={deleteClick}
                            /> */}
                        </div>
                    </div>
                    <div className={styles.headerBot}>
                        by&nbsp;
                        {book.author} (Author)
                    </div>
                </div>

                <ul className={styles.footer}>
                    <li className={`${styles.footer} ${styles.li}`}>
                        <div>
                            <strong>Isbn:</strong>
                        </div>
                        <div>
                            {book.isbn}
                        </div>
                    </li>

                    <li className={`${styles.footer} ${styles.li}`}>
                        <div>
                            <strong>Price:</strong>
                        </div>
                        {book.purchaseStatus === purchaseStatusConstants.bookAvailableForAdditionByCurrentFaculty ||
                            book.purchaseStatus === purchaseStatusConstants.bookAddedByCurrentFaculty
                            ?
                            <div>
                                0 {book.currencyCode.code}
                            </div>
                            :
                            <div>
                                {book.price} {book.currencyCode.code}
                            </div>
                        }

                    </li>
                    {book.purchaseStatus === purchaseStatusConstants.bookAvailableForPurchase && (
                        <>
                            <li className={`${styles.footer} ${styles.li}`}>
                                <>
                                    <div>
                                        <strong>Book status:</strong>
                                    </div>
                                    <div>
                                        <div>{book.purchaseStatus}</div>
                                    </div>
                                </>
                            </li>
                            <li className={styles.li}>
                                <>
                                    <MyButton setStyles={styles.btn} onClick={() => buyBook(book.id)}>
                                        Buy book
                                    </MyButton>
                                </>
                            </li>
                        </>
                    )}
                    {book.purchaseStatus === purchaseStatusConstants.bookPurchasedByCurrentFaculty && (
                        <>
                            <li className={`${styles.footer} ${styles.li}`}>
                                <>
                                    <div>
                                        <strong>Book status:</strong>
                                    </div>
                                    <div>
                                        <div>Purchased</div>
                                    </div>
                                </>
                            </li>
                        </>
                    )}
                    {book.purchaseStatus === purchaseStatusConstants.bookAvailableForAdditionByCurrentFaculty && (
                        <>
                            <li className={`${styles.footer} ${styles.li}`}>
                                <>
                                    <div>
                                        <strong>Book status:</strong>
                                    </div>
                                    <div>
                                        <div>{book.purchaseStatus}</div>
                                    </div>
                                </>
                            </li>
                            <li className={styles.li}>
                                <>
                                    <MyButton setStyles={styles.btn} onClick={() => addBook(book.id)}>
                                        Add book
                                    </MyButton>
                                </>
                            </li>
                        </>
                    )}
                    {book.purchaseStatus === purchaseStatusConstants.bookAddedByCurrentFaculty && (
                        <>
                            <li className={`${styles.footer} ${styles.li}`}>
                                <>
                                    <div>
                                        <strong>Book status:</strong>
                                    </div>
                                    <div>
                                        <div>Book added</div>
                                    </div>
                                </>
                            </li>
                        </>
                    )}
                </ul>
            </div >

















            {/* 

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
                    {book.purchaseStatus === purchaseStatusConstants.bookAvailableForPurchase && (
                        <>
                            <div>{book.purchaseStatus}</div>
                            <div> Price : {book.price} {book.currencyCode.code}</div>
                            <hr />
                        </>
                    )}

                    {book.isPurchase === false && (
                        <div>
                            <div>Price : sdsdsdsdsdFREE</div>
                            <hr />
                            <div>{book.purchaseStatus}</div>
                            <AddBook
                                book={book}
                                addBook={addBook}
                            />
                        </div>
                    )}

                    {book.isPurchase === null && (
                        <>
                            <div>{book.purchaseStatus}</div>
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
            </div > */}
        </>
    )
}

export default BookCard;

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