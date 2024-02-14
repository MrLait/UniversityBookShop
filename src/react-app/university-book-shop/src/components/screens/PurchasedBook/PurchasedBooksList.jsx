// @ts-nocheck
import React, { useState } from 'react'
import { useEffect } from 'react';
import BooksAvailableForFacultyApiService from '../../../API/BooksAvailableForFaculty';
import { booksAvailableForFacultyField } from '../../constants/initialStates';
import PurchasedBookCard from './PurchasedBookCard'
import styles from "./PurchasedBooksList.module.css"
import { CSSTransition, TransitionGroup } from 'react-transition-group'

const PurchasedBooksList = ({ purchasedBooks, setPurchasedBooks }) => {

    const deleteBook = (id) => {
        setPurchasedBooks(
            purchasedBooks.filter(p => p.id !== id)
        )
    }

    const updateErrorMessage = (id, errorMessage) => {
        const updatePurchasedBooks = purchasedBooks.map(pb => {
            if (pb.id === id)
                return {
                    ...pb,
                    book: {
                        ...pb.book,
                        errorMessage
                    }
                };
            return pb;
        })
        setPurchasedBooks(updatePurchasedBooks);
    }
    return (
        <>
            {purchasedBooks.length
                ?
                <TransitionGroup className={styles.gridSites}>
                    {purchasedBooks.map(b =>
                        <CSSTransition
                            key={b.id}
                            timeout={600}
                            classNames="pagination">
                            <div key={b.id}>
                                <PurchasedBookCard
                                    isPurchased={b.isPurchased}
                                    purchasedBookId={b.id}
                                    book={b.book}
                                    deleteBook={deleteBook}
                                    updateErrorMessage={updateErrorMessage}
                                />
                            </div>
                        </CSSTransition>
                    )}
                </TransitionGroup>
                :
                <div>
                    <hr />
                    There are no books
                </div>
            }
        </>

    )
}
export default PurchasedBooksList