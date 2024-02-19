// @ts-nocheck
import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';

import FacultyApiService from '../../../API/FacultyApiService';
import { facultyField } from '../../constants/initialStates';
import MyButton from '../../UI/button/MyButton';
import MyInput from '../../UI/input/MyInput';

import styles from './CreateFacultyForm.module.css';

const CreateFacultyForm = ({ modalShow, createFaculty }) => {
    const [faculty, setFaculty] = useState(facultyField);
    const [nameError, setNameError] = useState('');
    const [, setUniversityIdError] = useState('');
    const [loading, setLoading] = useState(false);

    const universityId = useParams().UniversityId;
    const rootStyles = [styles.loading];

    const postFaculty = async (e) => {
        e.preventDefault();
        setLoading(true);

        await FacultyApiService.post({ ...faculty, universityId: universityId })
            .then(response => {
                if (response.data && response.status === 200) {
                    const newFaculty = {
                        ...faculty,
                        id: response.data.data,
                    };
                    createFaculty(newFaculty);
                    setFaculty(facultyField);

                    setNameError('');
                    setUniversityIdError('');
                }
            }).catch(error => {
                if (error.response.status === 400) {
                    const validationErrors = error.response.data;
                    var statusCode = validationErrors.error.statusCode;
                    if (statusCode === 998) {
                        setNameError(validationErrors.data?.Name?.[0]);
                        setUniversityIdError(validationErrors.data?.UniversityId?.[0]);
                    }
                }
                if (error.response.data) {
                    //"ToDo faculty error"
                }
            }).finally(() => {
                setLoading(false);
            });
    };

    useEffect(() => {
        if (modalShow) {
            setNameError('');
            setUniversityIdError('');
            setFaculty(facultyField);
        }
    }, [modalShow]);

    if (loading) {
        rootStyles.push(styles.loadingActive);
        rootStyles.push(styles.loadingWhite);
    }
    return (
        <div className={styles.root}>
            <div className={styles.contentTabs}>
                {loading && (
                    <div className={rootStyles.join(' ')}>
                        <div className={styles.loadingSpinner}></div>
                    </div>
                )}
                <div className={styles.active}>
                    <div className={styles.container}>
                        <div className={styles.header}>
                            <div className={styles.inner}>
                                <h3 className={styles.title}>
                                    Welcome!
                                </h3>
                            </div>
                        </div>
                        <div className={styles.body}>
                            <div className={styles.inner}>
                                <h3 className={styles.title}>
                                    <strong>Create your faculty</strong>
                                </h3>
                                <form>
                                    <div className={styles.grid}>
                                        <div className={styles.gridCol}>
                                            <div className={styles.formField}>
                                                <label className={styles.formFieldLabel}>
                                                    Faculty name (*)
                                                </label>
                                                <MyInput
                                                    error={nameError}
                                                    value={faculty.name}
                                                    onChange={e => setFaculty({ ...faculty, name: e.target.value })}
                                                    type={'text'}
                                                    placeholder={'Faculty name'}
                                                    maxLength={150}
                                                />
                                            </div>
                                        </div>
                                        <div className={styles.gridCol}>
                                            <div className={styles.formField}>
                                                <MyButton
                                                    setStyles={styles.blackButton}
                                                    onClick={postFaculty}>
                                                    Create faculty
                                                </MyButton>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div >

    );
};

export default CreateFacultyForm;
