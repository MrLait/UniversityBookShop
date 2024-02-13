// @ts-nocheck
import React from 'react'
import FacultyApiService from '../../../API/FacultyApiService'
import styles from "./DeleteFaculty.module.css";

const DeleteFaculty = ({ faculty, updateFaculty, removeFaculty }) => {
    const updateFacultyField = (entity, fieldName, value) => {
        return {
            ...entity,
            [fieldName]: value,
        };
    };

    const deleteFaculty = async () => {
        await FacultyApiService.delete(faculty.id)
            .then(response => {
                if (response.status == 200)
                    if (response.data.isSucceeded) {
                        removeFaculty(faculty)
                    } else {
                        const errorMessage = response.data.error.message;
                        const updatedFaculty = updateFacultyField(faculty, 'errorMessage', errorMessage)
                        updateFaculty(updatedFaculty)
                    }
            }).catch(error => {
                if (error.response.data) {
                    const errorMessage = error.response.data.error.message;
                    const updatedFaculty = updateFacultyField(faculty, 'errorMessage', errorMessage)
                    updateFaculty(updatedFaculty)
                }
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
