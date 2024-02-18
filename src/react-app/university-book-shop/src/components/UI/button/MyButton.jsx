// @ts-nocheck
import React from 'react';

import styles from './MyButton.module.css';
const MyButton = ({ error, setStyles, children, ...props }) => {
    const additionalStyles = setStyles ? setStyles : '';
    const combinedStyles = `${styles.myBtn} ${additionalStyles}`;
    return (
        <>
            <button className={combinedStyles} {...props}>
                {children}
            </button >
            {error && <div className={styles.message}>{error}</div>}
        </>
    );
};

export default MyButton;
