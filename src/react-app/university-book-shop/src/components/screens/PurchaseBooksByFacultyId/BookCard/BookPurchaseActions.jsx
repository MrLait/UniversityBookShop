// @ts-nocheck
import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';

import { purchaseStatusConstants } from '../../../constants/purchaseStatusConstants';
import {
    usePurchaseBookMutation, useDeleteBookMutation, useAddBookMutation,
    useRemoveAvailableBookMutation, useGetAvailableBookQuery,
} from '../../../hooks/bookPurchaseActionsHooks';

import MyButtonSpinner from '../../../UI/spinner/MyModalSpinner/MyButtonSpinner';

import styles from './BookPurchaseActions.module.css';

const BookPurchaseActions = ({ book }) => {
    const facultyId = parseInt(useParams().facultyId || 0);
    const [prevPurchaseStatus, setPrevPurchaseStatus] = useState(book.purchaseStatus);
    const [errorMessage, setErrorMessage] = useState('');
    const removeBookMutation = useRemoveAvailableBookMutation(setErrorMessage);
    const addBookMutation = useAddBookMutation(setErrorMessage);
    const deleteBookMutation = useDeleteBookMutation(setErrorMessage);
    const purchaseBookMutation = usePurchaseBookMutation(setErrorMessage);
    const [isLoading, setIsLoading] = useState(false);

    const { refetch: getAvailableBook } = useGetAvailableBookQuery(book.id, facultyId);

    const handleRemoveBook = async () => {
        setIsLoading(true);
        const availableBook = await getAvailableBook();

        if (availableBook?.data?.availableBook?.bookId === book.id) {
            removeBookMutation.mutate([availableBook?.data?.availableBook?.id]);
        }
    };
    const handleAddBook = () => {
        setIsLoading(true);
        addBookMutation.mutate([book.id, facultyId]);
    };
    const handleDeleteBook = () => {
        setIsLoading(true);
        deleteBookMutation.mutate([book.id, facultyId]);
    };
    const handleBuyBook = () => {
        setIsLoading(true);
        purchaseBookMutation.mutate([book.id, facultyId]);
    };

    const isFetchError = React.useMemo(() => {
        return deleteBookMutation?.isError ||
            purchaseBookMutation?.isError ||
            addBookMutation?.isError ||
            removeBookMutation?.isError;
    }, [addBookMutation?.isError, deleteBookMutation?.isError, purchaseBookMutation?.isError, removeBookMutation?.isError]);

    const isPending = React.useMemo(() => {
        return deleteBookMutation?.data?.data?.isSucceeded;
    }, [deleteBookMutation?.data?.data?.isSucceeded]);

    useEffect(() => {
        if (book.purchaseStatus !== prevPurchaseStatus) {
            setIsLoading(false);
            setPrevPurchaseStatus(book.purchaseStatus);
        }
        if (isFetchError || isPending === false) {
            setIsLoading(false);
        }
    }, [book.purchaseStatus, isFetchError, prevPurchaseStatus, isPending]);

    return (
        <>
            <li className={`${styles.buttonWithError}`}>
                {isLoading ?
                    <MyButtonSpinner buttonStyle="Black" isPending={isLoading} />
                    :
                    <>
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
                    </>
                }
                {errorMessage && <div className={styles.message}>{errorMessage}</div>}
            </li>
        </>
    );
};

export default React.memo(BookPurchaseActions);
