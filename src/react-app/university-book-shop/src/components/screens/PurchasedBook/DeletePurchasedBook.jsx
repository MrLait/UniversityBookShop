// @ts-nocheck
import React from 'react'
import BooksAvailableForFacultyApiService from '../../../API/BooksAvailableForFaculty'
import styles from "./DeletePurchasedBook.module.css";

const DeletePurchasedBook = ({ id, deleteClick }) => {

    const deletePurchasedBook = async () => {
        await BooksAvailableForFacultyApiService.delete(id)
            .then(response => {
                if (response.status == 200 && response.data.isSucceeded) {
                    deleteClick(id)
                }
            });
    }
    return (
        <>
            <span className={styles.remove}
                onClick={deletePurchasedBook}>
                x
            </span>
        </>
    )
}

export default DeletePurchasedBook
