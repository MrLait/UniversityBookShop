// @ts-nocheck
import React from 'react';
import { useNavigate } from 'react-router-dom';

import { routePathsNavigate } from '../../../../router/routes';

import GoToIcon from '../../../../Assets/GoToIcon';

import { useDeleteUniversityByUniversityIdMutation } from '../../../hooks/universityHooks';

import MyButtonSpinner from '../../../UI/spinner/MyModalSpinner/MyButtonSpinner';

import styles from './UniversityCardNavBarSection.module.css';


const UniversityCardNavBarSection = ({ universityId, setErrorMessage }) => {
    const navigate = useNavigate();
    const deleteUniversity = useDeleteUniversityByUniversityIdMutation(setErrorMessage);
    const deleteUniversityHandler = () => {
        deleteUniversity.mutate([universityId]);
    };
    const goToHandler = () => {
        navigate(routePathsNavigate.UniversityId(universityId));
    };

    const isLoading = deleteUniversity?.isPending || deleteUniversity?.data?.data?.isSucceeded;

    return (
        <div className={styles.navbarInner}>
            <div
                className={styles.rolloverGoTo}
                onClick={goToHandler}
            >
                <GoToIcon />
            </div>
            {isLoading ?
                <MyButtonSpinner isPending={isLoading} />
                :
                <span
                    className={styles.remove}
                    onClick={deleteUniversityHandler}
                >
                    x
                </span>
            }
        </div >
    );
};

export default React.memo(UniversityCardNavBarSection);
