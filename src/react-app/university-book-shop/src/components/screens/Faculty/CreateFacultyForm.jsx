// @ts-nocheck
import React, { useState, useEffect } from 'react';

import { usePostFacultyMutation } from '../../hooks/facultyHooks';
import MyModalSpinner from '../../UI/spinner/MyModalSpinner/MyModalSpinner';
import MyModalLeftSection from '../../UI/modal/MyModalLeftSection';
import MyModalInput from '../../UI/modal/MyModalInput';
import MyModalButton from '../../UI/modal/MyModalButton';

import styles from './CreateFacultyForm.module.css';

const CreateFacultyForm = ({ modalShow, setModalShow, universityId }) => {
    const [facultyNameErrorMessage, setFacultyNameErrorMessage] = useState('');
    const [facultyName, setFacultyName] = useState('');
    const postFacultyMutation = usePostFacultyMutation(setFacultyNameErrorMessage, setModalShow);

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

    return (
        <div className={styles.root}>
            <div className={styles.contentTabs}>
                <MyModalSpinner isPending={postFacultyMutation?.isPending} />
                <div className={styles.active}>
                    <div className={styles.container}>
                        <MyModalLeftSection />
                        <div className={styles.body}>
                            <div className={styles.inner}>
                                <h3 className={styles.title}>
                                    <strong>Create your faculty</strong>
                                </h3>
                                <form>
                                    <div className={styles.grid}>
                                        <MyModalInput
                                            label="Faculty name (*)"
                                            error={facultyNameErrorMessage}
                                            value={facultyName}
                                            onChange={e => setFacultyName(e.target.value)}
                                            type={'text'}
                                            placeholder={'Faculty name'}
                                            maxLength={150}
                                        />
                                        <MyModalButton
                                            onClick={postFacultyHandle}
                                            label="Create faculty"
                                        />
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
