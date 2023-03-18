import React, { useState } from 'react'
import { useEffect } from 'react';
import { useParams } from 'react-router-dom';
import PurchasedBookApiService from '../../../API/PurchasedBookApiService';
import MyButton from '../../UI/button/MyButton';

const AddBook = ({ book, purchasedBooks, setPurchasedBooks }) => {
    const { faculty_id } = useParams()
    const [isPurchased, setIsPurchased] = useState(false);

    useEffect(() => {
        findPurchasedBooks()
    }, [purchasedBooks])

    const addBook = async (bookId) => {
        const response = await PurchasedBookApiService.post(bookId, faculty_id)
        const purchasedBook = {
            "id": response.data,
            "bookId": bookId,
            "facultyId": faculty_id,
            "book": book
        }
        setPurchasedBooks([...purchasedBooks, purchasedBook])
    }

    const findPurchasedBooks = () => {
        purchasedBooks.map(pb => {
            if (pb.bookId == book.id) {
                setIsPurchased(true)
            }
        })
    }
    return (
        <div>
            <div>
                {purchasedBooks.length
                    ?
                    <div>
                        {isPurchased
                            ?
                            <div>Purchased</div>
                            :
                            <MyButton onClick={() => addBook(book.id)}>Add</MyButton>
                        }
                    </div>
                    :
                    <MyButton onClick={() => addBook(book.id)}>Add</MyButton>
                }
            </div>
        </div >
    )
}

export default AddBook
