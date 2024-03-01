// @ts-nocheck
import React from 'react';

import BookHeader from '../../PurchaseBooksByFacultyId/BookCard/BookHeader';
import BookFooterItem from '../../PurchaseBooksByFacultyId/BookCard/BookFooterItem';
import BookPurchaseStatus from '../../PurchaseBooksByFacultyId/BookCard/BookPurchaseStatus';

import styles from './PurchasedBookCard.module.css';

const PurchasedBookCard = ({ book, isPurchased, purchasedBookId }) => {

    return (
        <>
            <div className={styles.bookCard}>
                <BookHeader
                    name={book.name} author={book.author}
                    bookId={purchasedBookId} isDelete={true}
                />
                <ul className={styles.footer}>
                    <BookFooterItem
                        label="Isbn"
                        value={book.isbn}
                    />
                    <BookPurchaseStatus
                        purchaseStatus={isPurchased ? 'has been purchased' : 'has been added'}
                    />
                    <BookFooterItem
                        label="Price"
                        value={`${book.price} ${book.currencyCode.code}`}
                    />
                </ul>
            </div >
        </>
    );
};

export default PurchasedBookCard;