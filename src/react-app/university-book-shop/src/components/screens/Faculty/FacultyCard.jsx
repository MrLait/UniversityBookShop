import React, { useState } from 'react'
import PurchasedBookApiService from '../../../API/PurchasedBookApiService';
import MyButton from '../../UI/button/MyButton'

const FacultyCard = ({ faculty }) => {
    const [purchasedBooks, PurchasedBooks] = useState([]);
    const getPurchasedBooks = async () => {
        console.log("open");
        const response = await PurchasedBookApiService.getAll()

        console.log(response.data);
    }
    return (
        <div>
            <div>
                <strong>
                    Faculty name: {faculty.name}
                </strong>
                <div>
                    <MyButton disabled>Delete faculty ToDo?</MyButton>
                    <MyButton onClick={getPurchasedBooks}>Open purchased books</MyButton>
                </div>
            </div>
        </div>
    )
}

export default FacultyCard
