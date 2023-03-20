// @ts-nocheck
import React from 'react'
import AddBook from './AddBook';
import styles from './Book.module.css';
import BookDetails from './BookDetails';

const Book = ({ book, purchasedBooksByFacultyId, setPurchasedBooksByFacultyId, isAtYourUniversity }) => {
    console.log(book.isAtYourUniversity);
    //console.log(isAtYourUniversity);
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
                {book.isAtYourUniversity
                    ?
                    <div className={styles.body}>
                        <div >
                            Price : 0
                        </div>
                        <hr />
                        <div className={styles.atYourInst}>
                            <div>
                                At you institute
                            </div>
                            {/* <div>
                                <AddBook
                                    book={book}
                                    purchasedBooksByFacultyId={purchasedBooksByFacultyId}
                                    setPurchasedBooksByFacultyId={setPurchasedBooksByFacultyId}
                                />
                            </div> */}
                        </div>
                    </div>
                    :
                    <div className={styles.body}>
                        <div >
                            Price : {book.price} {book.currencyCode.code}
                        </div>
                        <div >
                            <hr />
                            <AddBook
                                book={book}
                                purchasedBooksByFacultyId={purchasedBooksByFacultyId}
                                setPurchasedBooksByFacultyId={setPurchasedBooksByFacultyId}
                            />
                        </div>
                    </div>
                }

            </div>
            <BookDetails book={book} />
        </div >
    )
}

export default Book;