// @ts-nocheck
import React, { useState } from 'react';
import { useParams } from 'react-router-dom';

import { purchaseStatusConstants } from '../../../constants/purchaseStatusConstants';
import {
    usePurchaseBookMutation, useDeleteBookMutation, useAddBookMutation,
    useRemoveAvailableBookMutation, useGetAvailableBookQuery,
} from '../../../hooks/bookPurchaseActionsHooks';

import styles from './BookPurchaseActions.module.css';

const BookPurchaseActions = ({ book }) => {
    const facultyId = parseInt(useParams().facultyId || 0);
    const [errorMessage, setErrorMessage] = useState('');
    const removeBookMutation = useRemoveAvailableBookMutation(setErrorMessage);
    const addBookMutation = useAddBookMutation(setErrorMessage);
    const deleteBookMutation = useDeleteBookMutation(setErrorMessage);
    const purchaseBookMutation = usePurchaseBookMutation(setErrorMessage);

    const { refetch: getAvailableBook } = useGetAvailableBookQuery(book.id, facultyId);

    const handleRemoveBook = async () => {
        const availableBook = await getAvailableBook();

        if (availableBook?.data?.availableBook?.bookId === book.id) {
            removeBookMutation.mutate([availableBook?.data?.availableBook?.id]);
        }
    };

    const handleAddBook = () => addBookMutation.mutate([book.id, facultyId]);
    const handleDeleteBook = () => deleteBookMutation.mutate([book.id, facultyId]);
    const handleBuyBook = () => purchaseBookMutation.mutate([book.id, facultyId]);

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
            {errorMessage && <div className={styles.message}>{errorMessage}</div>}
        </li>
    );
};

export default React.memo(BookPurchaseActions);
