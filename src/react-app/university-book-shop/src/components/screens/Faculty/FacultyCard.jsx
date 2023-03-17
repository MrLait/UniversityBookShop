// @ts-nocheck
import React, { useState } from 'react'
import PurchasedBookApiService from '../../../API/PurchasedBookApiService';
import { purchasedBooksField } from '../../constants/initialStates';
import MyButton from '../../UI/button/MyButton'
import PurchasedBooks from '../PurchasedBook/PurchasedBooks';
import styles from './FacultyCard.module.css';

const FacultyCard = ({ faculty }) => {
    const [purchasedBooks, setPurchasedBooks] = useState(purchasedBooksField);
    const [isCardOpen, setIsCardOpen] = useState(false);

    const getPurchasedBooks = async () => {
        const response = await PurchasedBookApiService.getByFacultyId(faculty.id)
        setPurchasedBooks(response.data)
    }
    const showCard = () => {
        if (!isCardOpen) {
            setIsCardOpen(true)
            getPurchasedBooks()
        } else {
            setIsCardOpen(false)
            setPurchasedBooks(purchasedBooksField)
        }
    }
    return (
        <div >
            <div className={styles.myFacultyCard}>
                <strong>
                    Faculty name: {faculty.name}
                </strong>
                <div >
                    <MyButton disabled>Delete faculty ToDo?</MyButton>
                    <MyButton onClick={showCard}>Open purchased books</MyButton>
                </div>
                <h1></h1>
                <div >
                    <ul>
                        <PurchasedBooks purchasedBooks={purchasedBooks} />
                    </ul>
                </div>
            </div>
        </div>
    )
}

export default FacultyCard
