// @ts-nocheck
import React from 'react'
import AddBook from './AddBook';
import styles from './Book.module.css';
import BookDetails from './BookDetails';

const Book = ({ book }) => {
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
                        <div> В спике если книга есть уже у другого факультета ты должен это отобразить, типо at your institute и цену поставить 0</div>
                        <hr />
                        <div> , а если она уже куплена именно для твоего факультета написать purchased и убрать возможность её покупать, то есть по сути убрать кнопку</div>
                        <AddBook book={book} />
                    </div>
                </div>
            </div>
            <BookDetails book={book} />
        </div >
    )
}

export default Book;