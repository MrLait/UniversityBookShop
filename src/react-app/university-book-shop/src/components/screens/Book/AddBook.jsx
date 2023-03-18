import React from 'react'
import { useParams } from 'react-router-dom';
import PurchasedBookApiService from '../../../API/PurchasedBookApiService';
import MyButton from '../../UI/button/MyButton';

const AddBook = ({ book }) => {
    const { faculty_id } = useParams()
    const addBookClick = async (bookId) => {
        const response = await PurchasedBookApiService.post(bookId, faculty_id)
        console.log(response.data);
    }
    return (
        <div>
            <MyButton onClick={() => addBookClick(book.id)}>Add</MyButton>
        </div>
    )
}

export default AddBook
