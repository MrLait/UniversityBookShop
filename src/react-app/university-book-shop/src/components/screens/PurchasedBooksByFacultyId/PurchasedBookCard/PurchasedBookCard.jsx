// @ts-nocheck
import React from 'react';

import BookHeader from '../../PurchaseBooksByFacultyId/BookCard/BookHeader';
import BookFooterItem from '../../PurchaseBooksByFacultyId/BookCard/BookFooterItem';

import styles from './PurchasedBookCard.module.css';

const PurchasedBookCard = ({ book, isPurchased, availableBookId }) => {

    return (
        <div className={styles.bookCard}>
            <BookHeader
                bookId={availableBookId}
                name={book.name}
                author={book.author}
                isDeleteVisible={true}
            />
            <ul className={styles.footer}>
                <BookFooterItem label="Isbn" value={book.isbn} />
                <BookFooterItem label="Book status:" value={isPurchased ? 'has been purchased' : 'has been added'} />
                <BookFooterItem label="Price" value={`${book.price} ${book.currencyCode.code}`}
                />
            </ul>
        </div >
    );
};

export default React.memo(PurchasedBookCard);