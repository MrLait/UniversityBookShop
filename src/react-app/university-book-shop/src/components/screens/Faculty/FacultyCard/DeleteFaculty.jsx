// @ts-nocheck
import React from 'react';

import { useDeleteFacultyByFacultyIdMutation } from '../../../hooks/facultyHooks';

import styles from './DeleteFaculty.module.css';


const DeleteFaculty = ({ facultyId, setErrorMessage }) => {
    const deleteFaculty = useDeleteFacultyByFacultyIdMutation(setErrorMessage);

    const deleteFacultyHandler = (facultyId) => {
        deleteFaculty.mutate([facultyId]);
    };

    return (
        <>
            <span className={styles.remove}
                onClick={() => deleteFacultyHandler(facultyId)}>
                x
            </span>
        </>
    );
};

export default DeleteFaculty;
