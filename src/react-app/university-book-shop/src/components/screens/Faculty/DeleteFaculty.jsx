// @ts-nocheck
import React from 'react'
import FacultyApiService from '../../../API/FacultyApiService'
import styles from "./DeleteFaculty.module.css";

const DeleteFaculty = ({ faculty, removeFaculty }) => {

    const deleteFaculty = async () => {
        await FacultyApiService.delete(faculty.id)
            .then(response => {
                if (response.status == 200 && response.data.isSucceeded) {
                    removeFaculty(faculty)
                }
            }).catch(error => {
                const errorMessage = error.response.data;
            })
    }
    return (
        <>
            <span className={styles.remove}
                onClick={deleteFaculty}>
                x
            </span>
        </>
    )
}

export default DeleteFaculty
