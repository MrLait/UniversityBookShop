// @ts-nocheck
import React from 'react';

import { useDeleteFacultyByFacultyIdMutation } from '../../../hooks/facultyHooks';

import MyButtonSpinner from '../../../UI/spinner/MyModalSpinner/MyButtonSpinner';

import styles from './DeleteFaculty.module.css';

const DeleteFaculty = ({ facultyId, setErrorMessage }) => {
    const deleteFaculty = useDeleteFacultyByFacultyIdMutation(setErrorMessage);

    const deleteFacultyHandler = (facultyId) => {
        deleteFaculty.mutate([facultyId]);
    };

    const isLoading = deleteFaculty?.isPending || deleteFaculty?.data?.data?.isSucceeded;

    return (
        <>
            {isLoading ? <MyButtonSpinner isPending={isLoading} />
                :
                <span className={styles.remove}
                    onClick={() => deleteFacultyHandler(facultyId)}>
                    x
                </span>}
        </>
    );
};

export default DeleteFaculty;
