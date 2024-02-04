// @ts-nocheck
import React, { useState, useEffect } from 'react'
import UniversityApiService from '../../../API/UniversityApiService'
import { Currencies, universityField } from '../../constants/initialStates'
import MyButton from '../../UI/button/MyButton'
import MyInput from '../../UI/input/MyInput'
import MyTextArea from '../../UI/textarea/MyTextArea'
import styles from './CreateUniversityForm.module.css'

const CreateUniversityForm = ({ modalShow, create }) => {

    const [university, setUniversity] = useState(universityField)
    const [nameError, setNameError] = useState('')
    const [descriptionError, setDescriptionError] = useState('')
    const [loading, setLoading] = useState(false);

    const postUniversity = async (e) => {
        e.preventDefault()
        setLoading(true);
        university.currencyCodeId = Currencies.Usd;
        await UniversityApiService.post(university)
            .then(response => {
                if (response.data && response.status == 200) {
                    const newUniversity = {
                        ...university,
                        id: response.data.data
                    }
                    create(newUniversity);
                    setUniversity(universityField);

                    setNameError('');
                    setDescriptionError('');
                }

            }).catch(error => {
                if (error.response.status == 400) {
                    const validationErrors = error.response.data;
                    var statusCode = validationErrors.error.statusCode;
                    if (statusCode == 998) {
                        setNameError(validationErrors.data?.Name?.[0]);
                        setDescriptionError(validationErrors.data?.Description?.[0]);
                    }
                }
                if (error.response.data) {
                    //"ToDo Universities error"
                }
            }).finally(() => {
                setLoading(false);
            });
    }

    useEffect(() => {
        if (modalShow) {
            setNameError('');
            setDescriptionError('');
            setUniversity(universityField);
        }
    }, [modalShow]);

    const rootStyles = [styles.loading]
    if (loading) {
        rootStyles.push(styles.loadingActive);
        rootStyles.push(styles.loadingWhite);
    }

    return (
        <div className={styles.createUniversity}>
            <div className={styles.contentTabs}>
                {loading && (
                    <div className={rootStyles.join(' ')}>
                        <div className={styles.loadingSpinner}></div>
                    </div>
                )}
                <div className={styles.active}>
                    <div className={styles.createUniversityContainer}>
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
                                    <strong>Create your university</strong>
                                </h3>
                                <form>
                                    <div className={styles.grid}>
                                        <div className={styles.gridCol}>
                                            <div className={styles.formField}>
                                                <label className={styles.formFieldLabel}>
                                                    University name (*)
                                                </label>
                                                <MyInput
                                                    error={nameError}
                                                    value={university.name}
                                                    onChange={e => setUniversity({ ...university, name: e.target.value })}
                                                    type={'text'}
                                                    placeholder={'University name'}
                                                    maxLength={150}
                                                />
                                            </div>
                                        </div>
                                        <div className={styles.gridCol}>
                                            <div className={styles.formField}>
                                                <label className={styles.formFieldLabel}>
                                                    University description (*)
                                                </label>
                                                <MyTextArea
                                                    error={descriptionError}
                                                    value={university.description}
                                                    onChange={e => setUniversity({ ...university, description: e.target.value })}
                                                    type={'text'}
                                                    placeholder={'University description'}
                                                    maxLength={250}
                                                />
                                            </div>
                                        </div>
                                        <div className={styles.gridCol}>
                                            <div className={styles.formField}>
                                                <MyButton setStyles={styles.blackButton} onClick={postUniversity}>
                                                    Create university
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
        </div>
    );
}

export default CreateUniversityForm
