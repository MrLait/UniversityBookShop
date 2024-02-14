// @ts-nocheck
import React from 'react'
import BooksAvailableForFacultyApiService from '../../../API/BooksAvailableForFaculty'
import styles from "./DeletePurchasedBook.module.css";

const DeletePurchasedBook = ({ bookId, isPurchased, deleteClick }) => {

    const deletePurchasedBook = async (bookId) => {
        const test = 0;
        // await BooksAvailableForFacultyApiService.delete(bookId)
        //     .then(response => {
        //         if (response.status == 200 && response.data.isSucceeded) {
        //             deleteClick(id, facultyId)
        //         }
        //     });
    }

    const removePurchasedBook = async (bookId) => {
        const test = 0;
        // await BooksAvailableForFacultyApiService.delete(bookId)
        //     .then(response => {
        //         if (response.status == 200 && response.data.isSucceeded) {
        //             deleteClick(id)
        //         }
        //     });
    }
    return (
        <>
            <span className={styles.remove}
                onClick={() =>
                    isPurchased
                        ? deletePurchasedBook(bookId)
                        : removePurchasedBook(bookId)
                }>
                x
            </span>
        </>
    )
}

export default DeletePurchasedBook
