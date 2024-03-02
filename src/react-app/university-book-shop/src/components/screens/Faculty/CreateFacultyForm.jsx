// @ts-nocheck
import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';

import MyButton from '../../UI/button/MyButton';
import MyInput from '../../UI/input/MyInput';
import { usePostFacultyQuery } from '../../hooks/facultyHooks';

import styles from './CreateFacultyForm.module.css';

const CreateFacultyForm = ({ modalShow, setModalShow }) => {
    const [facultyNameErrorMessage, setFacultyNameErrorMessage] = useState('');
    const [facultyName, setFacultyName] = useState('');

    const universityId = useParams().UniversityId;
    const rootStyles = [styles.loading];

    const postFacultyMutation = usePostFacultyQuery(setFacultyNameErrorMessage, setModalShow);

    const postFacultyHandle = (e) => {
        e.preventDefault();
        postFacultyMutation.mutate([facultyName, universityId]);
    };

    useEffect(() => {
        if (modalShow) {
            setFacultyNameErrorMessage('');
            setFacultyName('');
        }
    }, [modalShow]);

    if (postFacultyMutation.isPending) {
        rootStyles.push(styles.loadingActive);
        rootStyles.push(styles.loadingWhite);
    }
    return (
        <div className={styles.root}>
            <div className={styles.contentTabs}>
                {postFacultyMutation.isPending && (
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
                                                    error={facultyNameErrorMessage}
                                                    value={facultyName}
                                                    onChange={e => setFacultyName(e.target.value)}
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
                                                    onClick={postFacultyHandle}
                                                >
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

export default React.memo(CreateFacultyForm);
