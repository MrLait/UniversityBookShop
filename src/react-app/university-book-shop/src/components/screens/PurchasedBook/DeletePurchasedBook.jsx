import React from 'react'
import PurchasedBookApiService from '../../../API/PurchasedBookApiService'
import MyButton from '../../UI/button/MyButton'

const DeletePurchasedBook = ({ id, deleteClick }) => {

    const deletePurchasedBook = async (id) => {
        await PurchasedBookApiService.delete(id)
            .then(response => {
                if (response.status == 204) {
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
