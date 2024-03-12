// @ts-nocheck
import React, { useState, useEffect } from 'react';

import { universityField } from '../../../constants/initialStates';
import { usePostUniversityMutation } from '../../../hooks/universityHooks';
import MyModalSpinner from '../../../UI/spinner/MyModalSpinner/MyModalSpinner';
import MyModalLeftSection from '../../../UI/modal/MyModalLeftSection';
import MyModalInput from '../../../UI/modal/MyModalInput';
import MyModalTextArea from '../../../UI/modal/MyModalTextArea';
import MyModalButton from '../../../UI/modal/MyModalButton';

import styles from './CreateUniversityForm.module.css';

const CreateUniversityForm = ({ modalShow, setModalShow }) => {
    const [university, setUniversity] = useState(universityField);
    const [nameError, setNameError] = useState('');
    const [descriptionError, setDescriptionError] = useState('');

    const postUniversityMutation = usePostUniversityMutation(setNameError, setDescriptionError, setModalShow);

    const postUniversityHandler = (e) => {
        e.preventDefault();
        postUniversityMutation.mutate([university]);
    };

    useEffect(() => {
        if (modalShow) {
            setNameError('');
            setDescriptionError('');
            setUniversity(universityField);
        }
    }, [modalShow]);

    return (
        <div className={styles.createUniversity}>
            <div className={styles.contentTabs}>
                <MyModalSpinner isPending={postUniversityMutation?.isPending} />
                <div className={styles.active}>
                    <div className={styles.createUniversityContainer}>
                        <MyModalLeftSection />
                        <div className={styles.body}>
                            <div className={styles.inner}>
                                <h3 className={styles.title}>
                                    <strong>Create your university</strong>
                                </h3>
                                <form>
                                    <div className={styles.grid}>
                                        <MyModalInput
                                            label="University name (*)"
                                            error={nameError}
                                            value={university.name}
                                            onChange={e => setUniversity({ ...university, name: e.target.value })}
                                            type={'text'}
                                            placeholder={'University name'}
                                            maxLength={150}
                                        />
                                        <MyModalTextArea
                                            label="University description (*)"
                                            isOpen={modalShow}
                                            error={descriptionError}
                                            value={university.description}
                                            onChange={e => setUniversity({ ...university, description: e.target.value })}
                                            type={'text'}
                                            placeholder={'University description'}
                                            maxLength={250}
                                        />
                                        <MyModalButton
                                            onClick={postUniversityHandler}
                                            label="Create university"
                                        />
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default React.memo(CreateUniversityForm);
