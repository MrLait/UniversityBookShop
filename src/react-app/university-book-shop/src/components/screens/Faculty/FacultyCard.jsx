// @ts-nocheck
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';
import { routePathsNavigate } from '../../../router/routes';
import MyButton from '../../UI/button/MyButton'
import PurchasedBooks from '../PurchasedBook/PurchasedBooks';
import styles from './FacultyCard.module.css';

const FacultyCard = ({ faculty }) => {
    const navigate = useNavigate();
    const [isPurchasedBooksVisible, setIsPurchasedBooksVisible] = useState(false);
    const showPurchasedBooks = () => {
        setIsPurchasedBooksVisible(prev => !prev)
    }
    return (
        <div >
            <div className={styles.myFacultyCard}>
                <strong>
                    Faculty name: {faculty.name}
                </strong>
                <div >
                    <MyButton disabled>Delete faculty ToDo?</MyButton>
                    <MyButton onClick={() => navigate(routePathsNavigate.SearchBookByFacultyId(faculty.id), { state: { universityId: faculty.universityId } })}>
                        Add book
                    </MyButton>
                    <MyButton onClick={showPurchasedBooks}>
                        Open purchased books
                    </MyButton>
                </div>
                <h1></h1>
                <div >
                    <ul>
                        <PurchasedBooks
                            facultyId={faculty.id}
                            isVisible={isPurchasedBooksVisible}
                        />
                    </ul>
                </div>
            </div>
        </div >
    )
}

export default FacultyCard
