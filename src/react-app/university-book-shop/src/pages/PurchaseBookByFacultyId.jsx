// @ts-nocheck
import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import BookApiService from '../API/BookApiService';
import Book from '../components/screens/Book/Book';
import styles from './PurchaseBookByFacultyId.module.css';
import BooksAvailableForFacultyApiService from '../API/BooksAvailableForFaculty';

const PurchaseBookByFacultyId = () => {
    const facultyId = parseInt(useParams().facultyId || 0);
    const [books, setBooks] = useState([]);
    const [isGetFilteredBook, setIsGetFilteredBook] = useState(false)
    const [booksAvailableForFaculty, setBooksAvailableForFaculty] = useState([]);

    useEffect(() => {
        getBooks();
    }, [])
    const updateBooksIsPurchased = (books) => {
        Promise.all(books.map(b => {
            return BooksAvailableForFacultyApiService.getByFacultyIdBookId(facultyId, b.id)
                .then(response => {
                    const isSucceeded = response.data.isSucceeded;
                    var data = response.data.data;
                    if (isSucceeded) {
                        var isPurchased = data.items[0].isPurchased
                        return { ...b, isPurchased }
                    }
                    return b;
                })
        }))
            .then(updatedBooks => {
                setBooks(updatedBooks);
                console.log(updatedBooks);
            })
    }

    const getBooks = async () => {
        await BookApiService.getAll()
            .then((response) => {
                const data = response.data.data.items;
                setBooks(data)
                setIsGetFilteredBook(true);
                updateBooksIsPurchased(data);
            })
    }

    return (
        <div>
            <div className={styles.wrap}>
                {books.map(b =>
                    <div key={b.id} className={styles.content} >
                        <div>Hello {b.id} </div>
                        <Book
                            book={b}
                            isGetFilteredBook={isGetFilteredBook}
                            setIsGetFilteredBook={setIsGetFilteredBook}
                        />
                    </div>
                )}
            </div>
        </div>
    )
}

export default PurchaseBookByFacultyId
