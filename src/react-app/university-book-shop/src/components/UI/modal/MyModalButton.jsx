// @ts-nocheck
import React from 'react';

import MyButton from '../button/MyButton';

import styles from './MyModalButton.module.css';

const MyModalButton = ({ onClick, label }) => {
    return (
        <div className={styles.gridCol}>
            <div className={styles.formField}>
                <MyButton setStyles={styles.blackButton}
                    onClick={onClick}>
                    {label}
                </MyButton>
            </div>
        </div>
    );
};

export default MyModalButton;
