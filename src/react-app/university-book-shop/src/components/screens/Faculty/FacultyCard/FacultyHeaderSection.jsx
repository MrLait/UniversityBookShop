// @ts-nocheck
import React, { useState } from 'react';

import DeleteFaculty from './DeleteFaculty';

import styles from './FacultyCard.module.css';

const FacultyHeaderSection = ({ name, facultyId }) => {
    const [errorMessage, setErrorMessage] = useState('');

    return (
        <div className={styles.header}>
            <div className={styles.headerTop}>
                <div className={styles.headerLeft}>
                    <strong>
                        {name}
                    </strong>
                </div>
                <div className={styles.headerRight}>
                    <DeleteFaculty
                        facultyId={facultyId}
                        setErrorMessage={setErrorMessage}
                    />
                </div>
            </div>
            {errorMessage &&
                <div className={styles.headerBot}>
                    <div className={styles.errorMessage}>{errorMessage}</div>
                </div>
            }
        </div>
    );
};

export default React.memo(FacultyHeaderSection);
