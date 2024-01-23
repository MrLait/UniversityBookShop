import React, { useState } from 'react'
import { useEffect } from 'react';
import BooksAvailableForFacultyApiService from '../../../API/BooksAvailableForFaculty';
import { booksAvailableForFacultyField } from '../../constants/initialStates';
import PurchasedBook from './PurchasedBook'

const PurchasedBooks = ({ facultyId, isVisible }) => {
    const [purchasedBooks, setPurchasedBooks] = useState(booksAvailableForFacultyField);
    const getPurchasedBooks = async () => {
        const response = await BooksAvailableForFacultyApiService.getByFacultyId(facultyId);
        console.log(response.data);
        setPurchasedBooks(response.data)
    }
    useEffect(() => {
        if (isVisible) {
            getPurchasedBooks()
        }
        else {
            setPurchasedBooks(booksAvailableForFacultyField)
        }
    }, [isVisible])

    const deleteBookClick = (id) => {
        console.log(id);
        setPurchasedBooks(
            purchasedBooks.filter(p => p.id !== id)
        )
    }

    return (
        <div>
            {purchasedBooks.length
                ?
                <div>
                    {purchasedBooks[0].id != 0
                        ?
                        <div >
                            <hr />
                            <div style={{
                                display: 'flex',
                                flexWrap: 'wrap',
                                justifyContent: 'flex-start'
                            }}>

                                {purchasedBooks.map(b =>
                                    <div key={b.id}
                                        style={{ flex: '1 1' }}
                                    >
                                        <PurchasedBook
                                            purchasedBookId={b.id}
                                            book={b.book}
                                            deleteClick={deleteBookClick}
                                        />
                                    </div>)
                                }
                            </div>
                        </div>
                        :
                        <div />
                    }
                </div>
                :
                <div>
                    <hr />
                    There is no books
                </div>
            }
        </div >
    )
}
export default PurchasedBooks
