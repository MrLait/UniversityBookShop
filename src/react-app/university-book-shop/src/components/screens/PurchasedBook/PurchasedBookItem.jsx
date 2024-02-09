// @ts-nocheck
import React from 'react'
import styles from './PurchasedBook.module.css';
import BookDetails from '../Book/BookDetails';
import DeletePurchasedBook from './DeletePurchasedBook';

const PurchasedBookItem = ({ book, purchasedBookId, deleteClick }) => {
    return (
        <div className={styles.myBook}>
            <div>
                <h1>
                    {book.name}
                </h1>
            </div>
            <div>
                by&nbsp;
                <span>{book.author} (Author)</span>
            </div>
            <div>
                <hr />
                <div className={styles.body}>
                    <div >
                        Price : {book.price} {book.currencyCode.code}
                    </div>
                    <div >
                        <DeletePurchasedBook id={purchasedBookId} deleteClick={deleteClick} />
                    </div>
                </div>
            </div>
            <BookDetails book={book} />
        </div >
    )
}

export default PurchasedBookItem;