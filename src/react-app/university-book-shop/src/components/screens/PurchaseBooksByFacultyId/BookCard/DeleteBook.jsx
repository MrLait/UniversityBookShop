// @ts-nocheck
import React from 'react';

import { useDeleteAvailableBookMutation } from '../../../hooks/booksAvailableForFacultyHooks';

import MyButtonSpinner from '../../../UI/spinner/MyModalSpinner/MyButtonSpinner';

import styles from './DeleteBook.module.css';

const DeleteBook = ({ bookId, setErrorMessage }) => {
    const deleteAvailableBook = useDeleteAvailableBookMutation(setErrorMessage);

    const deleteBookHandler = (bookId) => {
        deleteAvailableBook.mutate([bookId]);
    };
    const isLoading = deleteAvailableBook?.isPending || deleteAvailableBook?.data?.data?.isSucceeded;

    return (
        <>
            {isLoading ?
                <MyButtonSpinner isPending={isLoading} />
                :
                <span className={styles.remove}
                    onClick={() => deleteBookHandler(bookId)}>
                    x
                </span>}
        </>
    );
};

export default DeleteBook;
