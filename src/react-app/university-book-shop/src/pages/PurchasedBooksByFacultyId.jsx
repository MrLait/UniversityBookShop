// @ts-nocheck
import React, { useEffect, useState } from 'react'
import PurchasedBooksList from '../components/screens/PurchasedBook/PurchasedBooksList'
import { useParams } from 'react-router-dom'
import styles from './PurchasedBooksByFacultyId.module.css'
import FacultyApiService from '../API/FacultyApiService'

const PurchasedBooksByFacultyId = () => {
    const [faculty, setFaculty] = useState('');
    const [booksCount, setBooksCount] = useState(0);
    const facultyId = parseInt(useParams().faculty_id || 0);

    const getFacultyByFacultyId = async (facultyId) => {
        await FacultyApiService
            .getFacultyByFacultyId(facultyId)
            .then(response => {
                var isSucceeded = response.data.isSucceeded;
                var data = response.data.data;
                //ToDo if false;
                if (isSucceeded) {
                    setFaculty(data)
                }
            })
    }
    useEffect(() => {
        getFacultyByFacultyId(facultyId);
    }, [])

    return (
        <div className={styles.block}>
            <div className={styles.inner}>
                <div className={`${styles.contentHeaderTop} ${styles.textCenter}`}>
                    <div className={styles.headerTop}>
                        <h1 className={`${styles.headerTopText} ${styles.upperCase}`}>
                            Faculty
                            <br />
                            {faculty.name}
                        </h1>
                    </div>
                </div>
                <div className={styles.contentHeaderBot} >
                    <div className={styles.headerBotFlexLeft}>
                        <strong>{booksCount} </strong>
                        number of books available.
                    </div>
                    <div className={styles.headerBotFlexRight}>
                    </div>
                </div>
            </div>
            <div className={styles.contentBody}>
                <div className={styles.inner}>
                    <PurchasedBooksList
                        setBooksCount={setBooksCount}
                        facultyId={facultyId} />
                </div>
            </div>
        </div>
    )
}
export default PurchasedBooksByFacultyId