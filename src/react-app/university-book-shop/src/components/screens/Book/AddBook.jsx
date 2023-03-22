import React, { useState } from 'react'
import { useEffect } from 'react';


import PurchasedBookApiService from '../../../API/PurchasedBookApiService';
import MyButton from '../../UI/button/MyButton';

// const AddBook = ({ book, purchasedBooksByFacultyId, setPurchasedBooksByFacultyId, addBook }) => {
const AddBook = ({ book, addBook }) => {

    // const [isPurchased, setIsPurchased] = useState(false);
    // console.log(purchasedBooksByFacultyId);
    // useEffect(() => {
    //     findPurchasedBooks()
    // }, [purchasedBooksByFacultyId])

    // const findPurchasedBooks = () => {
    //     purchasedBooksByFacultyId.map(pb => {
    //         if (pb.bookId == book.id) {
    //             setIsPurchased(true)
    //         }
    //     })
    // }
    return (
        <div>
            <div>
                <MyButton onClick={() => addBook(book.id)}>Add</MyButton>
                {/* {purchasedBooksByFacultyId.length
                    ?
                    <div>
                        {purchasedBooksByFacultyId.isPurchased
                            ?
                            <div>Purchased</div>
                            :
                            <MyButton onClick={() => addBook(book.id)}>Add</MyButton>
                        }
                    </div>
                    :
                } */}
            </div>
        </div >
    )
}

export default AddBook
