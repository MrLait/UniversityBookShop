// @ts-nocheck
import React from 'react';

import styles from '../../../pages/purchasedBooksByFacultyId/PurchasedBooksByFacultyId.module.css';

const PurchasedBookHeaderSection = ({ facultyName }) => {
    return (
        <div className={`${styles.contentHeaderTop}`}>
            <div className={`${styles.headerTop} ${styles.textCenter}`} >
                <h1 className={`${styles.textSizeMedium}`}>
                    {facultyName}
                </h1>
            </div>
        </div>
    );
};

export default React.memo(PurchasedBookHeaderSection);
