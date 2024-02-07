// @ts-nocheck
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';
import { routePathsNavigate } from '../../../router/routes';
import PurchasedBooks from '../PurchasedBook/PurchasedBooks';
import DeleteFaculty from './DeleteFaculty';
import styles from './FacultyCard.module.css';
import { ReactComponent as ArrowDirectionLeft } from '../../../Assets/arrow_direction_left.svg';


const FacultyCard = ({ faculty, removeFaculty }) => {
    const navigate = useNavigate();
    const [isPurchasedBooksVisible, setIsPurchasedBooksVisible] = useState(false);

    return (
        <>
            <div className={styles.facultyCard}>
                <div className={styles.header}>
                    <div className={styles.headerLeft}>
                        <strong>
                            {faculty.name}
                        </strong>
                    </div>
                    <div className={styles.headerRight}>
                        <DeleteFaculty
                            faculty={faculty}
                            removeFaculty={removeFaculty}
                        />
                    </div>

                </div>
                <ul className={styles.footer}>
                    <li className={`${styles.footer} ${styles.li}`}>
                        <div>
                            <strong>Add book to faculty</strong>
                        </div>
                        <a
                            className={styles.rolloverArrowDirectionLeft}
                            onClick={() => navigate(routePathsNavigate.SearchBookByFacultyId(faculty.id),
                                { state: { universityId: faculty.universityId } })}>
                            <ArrowDirectionLeft className={styles.arrowDirectionLeft} />
                        </a>

                    </li>
                    <li className={`${styles.footer} ${styles.li}`}>
                        <strong>Open purchased book</strong>
                        <a
                            className={styles.rolloverArrowDirectionLeft}
                            onClick={() => setIsPurchasedBooksVisible(prev => !prev)}>
                            <ArrowDirectionLeft className={styles.arrowDirectionLeft} />
                        </a>
                    </li>
                </ul>
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
        </>
    )
}

export default FacultyCard
