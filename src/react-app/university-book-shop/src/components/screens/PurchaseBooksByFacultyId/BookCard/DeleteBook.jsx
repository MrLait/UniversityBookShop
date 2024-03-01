// @ts-nocheck
import React from 'react';

import { useDeleteAvailableBookMutation } from '../../../hooks/booksAvailableForFacultyHooks';

import styles from './DeleteBook.module.css';

const DeleteBook = ({ bookId, setErrorMessage }) => {
    const deleteAvailableBook = useDeleteAvailableBookMutation(setErrorMessage);

    const deleteBookHandler = (bookId) => {
        deleteAvailableBook.mutate([bookId]);
    };

    return (
        <>
            <span className={styles.remove}
                onClick={() => deleteBookHandler(bookId)}>
                x
            </span>
        </>
    );
};

export default DeleteBook;
