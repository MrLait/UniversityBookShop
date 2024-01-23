import React from 'react'
import BooksAvailableForFacultyApiService from '../../../API/BooksAvailableForFaculty'
import MyButton from '../../UI/button/MyButton'

const DeletePurchasedBook = ({ id, deleteClick }) => {

    const deletePurchasedBook = async (id) => {
        await BooksAvailableForFacultyApiService.delete(id)
            .then(response => {
                console.log(response);
                if (response.status == 200) {
                    deleteClick(id)
                }
            });
    }

    return (
        <div>
            <MyButton onClick={() => deletePurchasedBook(id)}>Delete</MyButton>
        </div>
    )
}

export default DeletePurchasedBook
