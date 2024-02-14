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

const BookCard = ({ book, buyBook, addBook, removeBook, deleteBook }) => {
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
                            <li className={`${styles.buttonWithError}`} >
                                <MyButton
                                    error={book.errorMessage}
                                    setStyles={styles.btn}
                                    onClick={() => buyBook(book.id)}>
                                    Buy book
                                </MyButton>
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
                            <li className={`${styles.buttonWithError}`} >
                                <MyButton
                                    error={book.errorMessage}
                                    setStyles={styles.btn}
                                    onClick={() => deleteBook(book.id)}>
                                    Delete purchased book
                                </MyButton>
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
                                <MyButton setStyles={styles.btn} onClick={() => addBook(book.id)}>
                                    Add book
                                </MyButton>
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
                            <li className={`${styles.buttonWithError}`} >
                                <MyButton
                                    error={book.errorMessage}
                                    setStyles={styles.btn}
                                    onClick={() => removeBook(book.id)}>
                                    Remove book
                                </MyButton>
                            </li>
                        </>
                    )}
                </ul>
            </div >
        </>
    )
}

export default BookCard;