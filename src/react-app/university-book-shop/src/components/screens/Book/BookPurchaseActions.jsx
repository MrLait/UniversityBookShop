// @ts-nocheck
import React from 'react';

import { purchaseStatusConstants } from '../../constants/purchaseStatusConstants';

import styles from './BookPurchaseActions.module.css';

const BookPurchaseActions = ({ book, buyBook, deleteBook, addBook, removeBook }) => {
    const handleBuyBook = () => buyBook(book.id);
    const handleDeleteBook = () => deleteBook(book.id);
    const handleAddBook = () => addBook(book.id);
    const handleRemoveBook = () => removeBook(book.id);

    return (
        <li className={`${styles.buttonWithError}`}>
            {book.purchaseStatus === purchaseStatusConstants.bookAvailableForPurchase && (
                <button
                    className={styles.blackButton}
                    onClick={handleBuyBook}>
                    Buy book
                </button>
            )}
            {book.purchaseStatus === purchaseStatusConstants.bookPurchasedByCurrentFaculty && (
                <button
                    className={styles.blackButton}
                    onClick={handleDeleteBook}>
                    Delete purchased book
                </button>
            )}
            {book.purchaseStatus === purchaseStatusConstants.bookAvailableForAdditionByCurrentFaculty && (
                <button
                    className={styles.blackButton}
                    onClick={handleAddBook}>
                    Add book
                </button>
            )}
            {book.purchaseStatus === purchaseStatusConstants.bookAddedByCurrentFaculty && (
                <button
                    className={styles.blackButton}
                    onClick={handleRemoveBook}>
                    Remove book
                </button>
            )}
            {book.errorMessage && <div className={styles.message}>{book.errorMessage}</div>}
        </li>
    );
};

export default React.memo(BookPurchaseActions);
