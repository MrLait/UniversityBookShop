// @ts-nocheck
import React from 'react';

import styles from './MyModalSpinner.module.css';

const MyModalSpinner = ({ isPending }) => {
    const rootStyles = [styles.loading];
    if (isPending) {
        rootStyles.push(styles.loadingActive);
        rootStyles.push(styles.loadingWhite);
    }

    return (
        <>
            {isPending && (
                <div className={rootStyles.join(' ')}>
                    <div className={styles.loadingSpinner}></div>
                </div>
            )}
        </>
    );
};

export default MyModalSpinner;
