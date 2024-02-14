// @ts-nocheck
import React from 'react'
import styles from './PurchasedBookCard.module.css';
import BookDetails from '../Book/BookDetails';
import DeletePurchasedBook from './DeletePurchasedBook';

const PurchasedBookCard = ({ book, isPurchased, purchasedBookId, deleteClick }) => {
    return (
        <>
            <div className={styles.bookCard}>
                <div className={styles.header}>
                    <div className={styles.headerTop}>
                        <div className={styles.headerLeft}>
                            <strong>
                                {book.name}
                            </strong>
                        </div>
                        <div className={styles.headerRight}>
                            <DeletePurchasedBook
                                bookId={purchasedBookId}
                                isPurchased={isPurchased}
                                deleteClick={deleteClick}
                            />
                        </div>
                    </div>
                    <div className={styles.headerBot}>
                        by&nbsp;
                        {book.author} (Author)
                    </div>
                </div>

                <ul className={styles.footer}>
                    <li className={`${styles.footer} ${styles.li}`}>
                        <div>
                            <strong>Isbn:</strong>
                        </div>
                        <div>
                            {book.isbn}
                        </div>
                    </li>
                    <li className={`${styles.footer} ${styles.li}`}>
                        <>
                            <div>
                                <strong>Book status:</strong>
                            </div>
                            <div>
                                <div>{isPurchased ? "has been purchased" : "has been added"}</div>
                            </div>
                        </>
                    </li>
                    <li className={`${styles.footer} ${styles.li}`}>
                        <div>
                            <strong>Price:</strong>
                        </div>
                        <div>
                            {book.price} {book.currencyCode.code}
                        </div>
                    </li>
                </ul>
            </div >
        </>
    )
}

export default PurchasedBookCard;