// @ts-nocheck
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';
import { routePathsNavigate } from '../../../router/routes';
import MyButton from '../../UI/button/MyButton'
import PurchasedBooks from '../PurchasedBook/PurchasedBooks';
import DeleteFaculty from './DeleteFaculty';
import styles from './FacultyCard.module.css';

const FacultyCard = ({ faculty, removeFaculty }) => {
    const navigate = useNavigate();
    const [isPurchasedBooksVisible, setIsPurchasedBooksVisible] = useState(false);

    return (
        <div >
            <div className={styles.myFacultyCard}>
                <strong>
                    Faculty name: {faculty.name}
                </strong>
                <div >
                    <DeleteFaculty
                        faculty={faculty}
                        removeFaculty={removeFaculty}
                    />
                    <MyButton onClick={() => navigate(routePathsNavigate.SearchBookByFacultyId(faculty.id), { state: { universityId: faculty.universityId } })}>
                        Add book
                    </MyButton>
                    <MyButton onClick={() => setIsPurchasedBooksVisible(prev => !prev)}>
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
