// @ts-nocheck
import React, { useEffect, useState } from 'react'
import BookApiService from '../API/BookApiService';
import Book from '../components/screens/Book/Book';
import styles from './PurchaseBookByFacultyId.module.css';
import { useLocation, useParams } from 'react-router-dom';
import PurchasedBookApiService from '../API/PurchasedBookApiService';
import BooksAvailableForFacultyApiService from '../API/BooksAvailableForFaculty';

const PurchaseBookByFacultyId = () => {
    const [books, setBooks] = useState([]);
    const [isGetFilteredBook, setIsGetFilteredBook] = useState(false)
    // const [updatedBooks, setUpdatedBooks] = useState([]);
    // const [purchasedBooksByFacultyId, setPurchasedBooksByFacultyId] = useState([]);
    // const [purchasedBooksByUniversityId, setPurchasedBooksByUniversityId] = useState([]);
    // const [isAtYourUniversity, setIsAtYourUniversity] = useState();

    const { faculty_id } = useParams()
    const { universityId } = useLocation().state

    useEffect(() => {
        getBooks();
    }, [])

    // useEffect(() => {
    //     findPurchasedBooksByUniversity();
    // }, [purchasedBooksByUniversityId])

    const getBooks = async () => {
        await BookApiService.getAll()
            .then((response) => {
                setBooks(response.data)
                setIsGetFilteredBook(true);
                // BooksAvailableForFacultyApiService.getByFacultyId(faculty_id)
                //     .then((response) => {
                //         console.log(response.data);
                //         setPurchasedBooksByFacultyId(response.data)
                //         // PurchasedBookApiService.getByUniversityId(universityId)
                //         //     .then((response) => {
                //         //         setPurchasedBooksByUniversityId(response.data)
                //         //         console.log(response);
                //         //         findPurchasedBooksByUniversity()
                //         //     })
                //     })
            })

    }
    // const findPurchasedBooksByUniversity = () => {
    //     const array = []
    //     const newBook = books.map(b => {
    //         b = { ...b, isAtYourUniversity: false }
    //         purchasedBooksByUniversityId.map(pbu => {
    //             if (b.id == pbu.bookId && faculty_id != pbu.facultyId) {
    //                 array.push({ isAtYourUniversity: true, bookId: b.id })
    //                 return b = { ...b, isAtYourUniversity: true }
    //             }
    //         })
    //         return b;
    //     })
    //     console.log(newBook);

    //     setUpdatedBooks(newBook);
    //     setIsAtYourUniversity(array)
    // }

    return (
        <div>
            <div className={styles.wrap}>
                {books.map(b =>
                    <div key={b.id} className={styles.content} >
                        <Book
                            book={b}
                            isGetFilteredBook={isGetFilteredBook}
                            setIsGetFilteredBook={setIsGetFilteredBook}
                        // purchasedBooksByFacultyId={purchasedBooksByFacultyId}
                        // setPurchasedBooksByFacultyId={setPurchasedBooksByFacultyId}
                        // isAtYourUniversity={isAtYourUniversity}
                        />
                    </div>
                )}
            </div>
        </div>
    )
}

export default PurchaseBookByFacultyId
