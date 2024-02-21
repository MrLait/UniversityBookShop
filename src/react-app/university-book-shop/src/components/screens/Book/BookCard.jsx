// @ts-nocheck
import React from 'react';

import { purchaseStatusConstants } from '../../constants/purchaseStatusConstants';

import styles from './BookCard.module.css';

import BookHeader from './BookHeader';
import BookFooterItem from './BookFooterItem';
import BookPurchaseStatus from './BookPurchaseStatus';
import BookPurchaseActions from './BookPurchaseActions';

const BookCard = ({ book, buyBook, addBook, removeBook, deleteBook }) => {
    const priceStatus = book.purchaseStatus === purchaseStatusConstants.bookAvailableForAdditionByCurrentFaculty ||
        book.purchaseStatus === purchaseStatusConstants.bookAddedByCurrentFaculty
        ? `0 ${book.currencyCode.code}`
        : `${book.price} ${book.currencyCode.code}`;

    return (
        <>
            <div className={styles.bookCard}>
                <BookHeader name={book.name} author={book.author} />
                <ul className={styles.footer}>
                    <BookFooterItem
                        label="Isbn"
                        value={book.isbn}
                    />
                    <BookFooterItem
                        label="Price"
                        value={priceStatus}
                    />
                    {(book.purchaseStatus === purchaseStatusConstants.bookAvailableForPurchase ||
                        book.purchaseStatus === purchaseStatusConstants.bookAvailableForAdditionByCurrentFaculty) && (
                            <BookPurchaseStatus purchaseStatus={book.purchaseStatus} />
                        )}
                    {(book.purchaseStatus === purchaseStatusConstants.bookPurchasedByCurrentFaculty) && (
                        <BookPurchaseStatus purchaseStatus={'Purchased'} />
                    )}
                    {book.purchaseStatus === purchaseStatusConstants.bookAddedByCurrentFaculty && (
                        <BookPurchaseStatus purchaseStatus={'Book added'} />
                    )}
                    <BookPurchaseActions
                        book={book}
                        buyBook={buyBook}
                        deleteBook={deleteBook}
                        addBook={addBook}
                        removeBook={removeBook}
                    />
                </ul>
            </div >
        </>
    );
};

export default React.memo(BookCard);