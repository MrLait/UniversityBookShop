// @ts-nocheck
import React from 'react';

import styles from './UniversityByUniversityIdHeaderSection.module.css';
const UniversityByUniversityIdHeaderSection = ({ name, description }) => {
    return (
        <div className={`${styles.contentHeaderTop} `}>
            <div className={`${styles.headerTop} ${styles.textCenter}`} >
                <h1 className={`${styles.textSizeMedium}`}>
                    {name}
                </h1>
            </div>
            <div className={`${styles.textCenter}`} >
                <span className={styles.headerBotText}>
                    {description}
                </span>
            </div>
        </div>
    );
};

export default React.memo(UniversityByUniversityIdHeaderSection);
