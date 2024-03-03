// @ts-nocheck
import React from 'react';

import styles from './PurchaseBookHeaderSection.module.css';

const PurchaseBookHeaderSection = () => {
    return (
        <div className={`${styles.contentHeaderTop} ${styles.textCenter}`}>
            <div className={`${styles.headerTop}`}>
                <h1 className={`${styles.textSizeBig} ${styles.upperCase}`}>
                    Books
                </h1>
            </div>
        </div>
    );
};

export default React.memo(PurchaseBookHeaderSection);
