// @ts-nocheck
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';
import { routePathsNavigate } from '../../../router/routes';
import DeleteFaculty from './DeleteFaculty';
import styles from './FacultyCard.module.css';
import { ReactComponent as ArrowDirectionLeft } from '../../../Assets/arrow_direction_left.svg';
import BooksAvailableForFacultyApiService from '../../../API/BooksAvailableForFaculty';

const FacultyCard = ({ faculty, removeFaculty }) => {
    const navigate = useNavigate();
    const [isPurchasedBooksVisible, setIsPurchasedBooksVisible] = useState(false);

    const getPurchasedBooks = async (facultyId) => {
        await BooksAvailableForFacultyApiService.getByFacultyId(facultyId)
            .then((response) => {
                var isSucceeded = response.data.isSucceeded;
                if (response.status === 200 && isSucceeded) {
                    navigate(routePathsNavigate.FacultyBooksByFacultyId(faculty.universityId, faculty.id))
                }
                if (isSucceeded == false && response.data.error.statusCode === 404) {
                    setIsPurchasedBooksVisible(true);
                }
            });
    }

    const togglePurchasedBooksVisibility = async (facultyId) => {
        if (isPurchasedBooksVisible) {
            setIsPurchasedBooksVisible(false);
        } else {
            await getPurchasedBooks(facultyId);
        }
    };

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
                            onClick={() => togglePurchasedBooksVisibility(faculty.id)}
                        >
                            <ArrowDirectionLeft className={styles.arrowDirectionLeft} />
                        </a>
                    </li>
                    {isPurchasedBooksVisible ?
                        <li className={`${styles.footer} ${styles.li}`}>
                            <strong>There is not purchased books.</strong>
                        </li>
                        :
                        <></>
                    }
                </ul>
            </div >
        </>
    )
}

export default FacultyCard
