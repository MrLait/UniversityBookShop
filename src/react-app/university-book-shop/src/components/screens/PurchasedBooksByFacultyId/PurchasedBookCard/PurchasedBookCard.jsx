// @ts-nocheck
import React from 'react';

import DeletePurchasedBook from '../../PurchaseBooksByFacultyId/BookCard/DeleteBook';
import BookHeader from '../../PurchaseBooksByFacultyId/BookCard/BookHeader';
import BookFooterItem from '../../PurchaseBooksByFacultyId/BookCard/BookFooterItem';
import BookPurchaseStatus from '../../PurchaseBooksByFacultyId/BookCard/BookPurchaseStatus';

import styles from './PurchasedBookCard.module.css';

const PurchasedBookCard = ({ book, isPurchased, purchasedBookId, updateErrorMessage, deleteBook }) => {

    return (
        <>
            <div className={styles.bookCard}>
                <BookHeader
                    name={book.name} author={book.author}
                    bookId={book.div} isDelete={true}
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




{/* <div className={styles.header}> */ }
{/* <div className={styles.headerTop}>
                        <div className={styles.headerLeft}>
                            <strong>
                                {book.name}
                            </strong>
                        </div>
                        <div className={styles.headerRight}>
                            <DeletePurchasedBook
                                bookId={purchasedBookId}
                                updateErrorMessage={updateErrorMessage}
                                deleteBook={deleteBook}
                            />
                        </div>
                    </div>
                    <div className={styles.headerBot}>
                        by&nbsp;
                        {book.author} (Author)
                    </div> */}
{/* {book.errorMessage &&
                        <div className={styles.errorMessage}>
                            {book.errorMessage}
                        </div>
                    } */}

{/* </div> */ }