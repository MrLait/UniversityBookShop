// @ts-nocheck
import React, { useState } from 'react'
import { useEffect } from 'react';
import BooksAvailableForFacultyApiService from '../../../API/BooksAvailableForFaculty';
import { booksAvailableForFacultyField } from '../../constants/initialStates';
import PurchasedBookCard from './PurchasedBookCard'
import styles from "./PurchasedBooksList.module.css"
import { CSSTransition, TransitionGroup } from 'react-transition-group'

const PurchasedBooksList = ({ setBooksCount, facultyId }) => {
    const [purchasedBooks, setPurchasedBooks] = useState(booksAvailableForFacultyField);
    const getPurchasedBooks = async () => {
        await BooksAvailableForFacultyApiService.getByFacultyId(facultyId)
            .then((response) => {
                var isSucceeded = response.data.isSucceeded;
                if (response.status === 200 && isSucceeded) {
                    const books = response.data.data.items;
                    setPurchasedBooks(books)
                    setBooksCount(books.length)
                }
            });
    }
    useEffect(() => {
        getPurchasedBooks()
    }, [])

    const deleteBookClick = (id) => {
        setPurchasedBooks(
            purchasedBooks.filter(p => p.id !== id)
        )
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
                                    purchasedBookId={b.id}
                                    book={b.book}
                                    deleteClick={deleteBookClick}
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