// @ts-nocheck
import React from 'react'
import AddBook from './AddBook';
import styles from './Book.module.css';
import BookDetails from './BookDetails';
import { useLocation, useParams } from 'react-router-dom';
import BooksAvailableForFacultyApiService from '../../../API/BooksAvailableForFaculty';
import BooksPurchasedByUniversityApiService from '../../../API/BooksPurchasedByUniversity';
import { useState } from 'react';
import { useEffect } from 'react';
import { purchasedBookField } from '../../constants/initialStates'
// const Book = ({ book, purchasedBooksByFacultyId, setPurchasedBooksByFacultyId }) => {
const Book = ({ book, isGetFilteredBook, setIsGetFilteredBook }) => {
    const { faculty_id } = useParams()
    const { universityId } = useLocation().state
    const [purchasedBook, setPurchasedBook] = useState(purchasedBookField);
    const [isBookAtUniversity, setIsBookAtUniversity] = useState(false)

    const getPurchasedBooks = async () => {
        await BooksAvailableForFacultyApiService.getByFacultyIdBookId(faculty_id, book.id)
            .then((response) => {
                if (response.status == 200) {
                    setPurchasedBook(response.data)
                    setIsBookAtUniversity(false);
                }
                if (response.data == '' && response.status == 204) {
                    BooksPurchasedByUniversityApiService.getIsBookAtUniversity(book.id, universityId)
                        .then((isBookAtUniversityResponse) => {
                            setIsBookAtUniversity(isBookAtUniversityResponse.data);
                            setPurchasedBook(response.data)
                        })
                }
            })
    }
    useEffect(() => {
        if (isGetFilteredBook) {
            getPurchasedBooks()
        }
    }, [])

    const addBook = async (bookId) => {
        await BooksAvailableForFacultyApiService.post(bookId, faculty_id, universityId)
            .then(() => {
                getPurchasedBooks()
            })
    }

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
                {isBookAtUniversity
                    ?
                    <div>
                        <div>Price : FREE</div>
                        <hr />
                        <div>At University</div>
                        <AddBook
                            book={book}
                            addBook={addBook}
                        />
                    </div>
                    :
                    <div>
                        {purchasedBook.bookId == book.id
                            ?
                            <div>
                                {purchasedBook.isPurchased
                                    ?
                                    <div>
                                        <div> Price : {book.price} {book.currencyCode.code}</div>
                                        <hr />
                                        <div>Purchased</div>
                                    </div>
                                    :
                                    <div>
                                        <div>Price : FREE</div>
                                        <hr />
                                        <div>At your faculty</div>
                                    </div>
                                }
                            </div>
                            :
                            <div>
                                <div> Price : {book.price} {book.currencyCode.code}</div>
                                <hr />
                                <div>
                                    <AddBook
                                        book={book}
                                        addBook={addBook}
                                    />
                                </div>
                            </div>
                        }
                    </div>
                }
            </div>
            <BookDetails book={book} />
        </div >
    )
}

export default Book;


{/* {book.isAtYourUniversity
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
                                addBook={addBook}
                            />
                        </div>
                    </div>
                } */}