// @ts-nocheck
import React from 'react'
import AddBook from './AddBook';
import styles from './Book.module.css';
import BookDetails from './BookDetails';

const Book = ({ book, purchasedBooks, setPurchasedBooks }) => {
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
                        <AddBook
                            book={book}
                            purchasedBooks={purchasedBooks}
                            setPurchasedBooks={setPurchasedBooks}
                        />
                    </div>
                </div>
            </div>
            <BookDetails book={book} />
        </div >
    )
}

export default Book;