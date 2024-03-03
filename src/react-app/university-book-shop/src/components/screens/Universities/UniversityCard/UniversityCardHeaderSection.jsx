// @ts-nocheck
import React from 'react';
import { useNavigate } from 'react-router-dom';

import { routePathsNavigate } from '../../../../router/routes';

import styles from './UniversityCardHeaderSection.module.css';

const UniversityCardHeaderSection = ({ id, name, description, errorMessage }) => {
    const navigate = useNavigate();

    return (
        <div className={styles.header}>
            <div className={styles.title}
                onClick={() => navigate(routePathsNavigate.UniversityId(id))}
            >
                {name}
            </div>
            <div className={styles.description}>{description}</div>
            {errorMessage &&
                <div className={styles.errorMessage}>{errorMessage}
                </div>
            }
        </div>
    );
};

export default React.memo(UniversityCardHeaderSection);
