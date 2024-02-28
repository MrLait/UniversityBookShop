// @ts-nocheck
import React from 'react';
import { useParams } from 'react-router-dom';


import { purchaseStatusConstants } from '../../../constants/purchaseStatusConstants';
import {
    usePurchaseBookMutation, useDeleteBookMutation, useAddBookMutation,
    useRemoveAvailableBookMutation, useGetAvailableBookQuery,
} from '../../../hooks/bookPurchaseActionsHooks';


import styles from './BookPurchaseActions.module.css';


const BookPurchaseActions = ({ book }) => {
    const facultyId = parseInt(useParams().facultyId || 0);

    const removeBookMutation = useRemoveAvailableBookMutation();
    const addBookMutation = useAddBookMutation();
    const deleteBookMutation = useDeleteBookMutation();
    const purchaseBookMutation = usePurchaseBookMutation();
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
            {book.errorMessage && <div className={styles.message}>{book.errorMessage}</div>}
        </li>
    );
};

export default React.memo(BookPurchaseActions);
