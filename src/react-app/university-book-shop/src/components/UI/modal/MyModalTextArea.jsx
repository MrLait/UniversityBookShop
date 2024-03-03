// @ts-nocheck
import React from 'react';

import MyTextArea from '../textarea/MyTextArea';

import styles from './MyModalTextArea.module.css';

const MyModalTextArea = ({ label, isOpen, error, value, onChange, type, placeholder, maxLength }) => {
    return (
        <div className={styles.gridCol}>
            <div className={styles.formField}>
                <label className={styles.formFieldLabel}>
                    {label}
                </label>
                <MyTextArea
                    isOpen={isOpen}
                    error={error}
                    value={value}
                    onChange={onChange}
                    type={type}
                    placeholder={placeholder}
                    maxLength={maxLength}
                />
            </div>
        </div>
    );
};

export default MyModalTextArea;
