// @ts-nocheck
import React from 'react';

import BooksAvailableForFacultyApiService from '../../../API/BooksAvailableForFaculty';

import styles from './DeletePurchasedBook.module.css';

const DeletePurchasedBook = ({ bookId, updateErrorMessage, deleteBook }) => {

    const deleteAvailableBook = async (bookId) => {
        await BooksAvailableForFacultyApiService.deleteAvailableBook(bookId)
            .then(response => {
                var isSucceeded = response.data.isSucceeded;

                if (isSucceeded) {
                    deleteBook(bookId);
                } else {
                    var errorMessage = response.data.error.message;
                    updateErrorMessage(bookId, errorMessage);
                }
            })
            .catch(error => {
                var isSucceeded = error.response.data.isSucceeded;
                const statusCode = error.response.data.error.statusCode;
                if (!isSucceeded && statusCode === 404) {
                    updateErrorMessage(bookId, 'Book can\'t be removed.');
                }
            });
    };

    return (
        <>
            <span className={styles.remove}
                onClick={() => deleteAvailableBook(bookId)}>
                x
            </span>
        </>
    );
};

export default DeletePurchasedBook;
