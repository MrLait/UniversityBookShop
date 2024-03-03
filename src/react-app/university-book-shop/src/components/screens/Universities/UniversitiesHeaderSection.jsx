// @ts-nocheck
import React from 'react';

import CreateUniversity from './Create/CreateUniversity';

import styles from './UniversitiesHeaderSection.module.css';

const UniversitiesHeaderSection = () => {
    return (
        <div className={styles.contentHeader}>
            <div className={styles.inner}>
                <div className={styles.createUniversity}>
                    <div className={styles.contentHeaderLeft}>
                        <h5>
                            Welcome to my website
                            <br />
                            where you can create universities, faculties, and manage book purchases.
                        </h5>
                    </div>
                    <div className={styles.contentHeaderRight}>
                        <CreateUniversity />
                    </div>
                </div>
            </div>
        </div>
    );
};


export default React.memo(UniversitiesHeaderSection);
