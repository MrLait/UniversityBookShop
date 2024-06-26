// @ts-nocheck
import React from 'react';

import { purchaseStatusConstants } from '../../../constants/purchaseStatusConstants';

import styles from './BookCard.module.css';
import BookHeader from './BookHeader';
import BookFooterItem from './BookFooterItem';
import BookPurchaseActions from './BookPurchaseActions';

const BookCard = ({ book }) => {
    const priceStatus = book.purchaseStatus === purchaseStatusConstants.bookAvailableForAdditionByCurrentFaculty ||
        book.purchaseStatus === purchaseStatusConstants.bookAddedByCurrentFaculty
        ? `0 ${book.currencyCode.code}`
        : `${book.price} ${book.currencyCode.code}`;

    return (
        <>
            <div className={styles.bookCard}>
                <BookHeader
                    deleteClassName={styles.bookCard}
                    name={book.name} author={book.author}
                />
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
                            <BookFooterItem label="Book status" value={book.purchaseStatus} />
                        )}
                    {(book.purchaseStatus === purchaseStatusConstants.bookPurchasedByCurrentFaculty) && (
                        <BookFooterItem label="Book status" value={'Purchased'} />
                    )}
                    {book.purchaseStatus === purchaseStatusConstants.bookAddedByCurrentFaculty && (
                        <BookFooterItem label="Book status" value={'Book added'} />
                    )}
                    <BookPurchaseActions
                        book={book}
                    />
                </ul>
            </div >
        </>
    );
};

export default React.memo(BookCard);