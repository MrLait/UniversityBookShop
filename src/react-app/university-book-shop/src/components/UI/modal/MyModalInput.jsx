// @ts-nocheck
import React from 'react';

import MyInput from '../input/MyInput';

import styles from './MyModalInput.module.css';

const MyModalInput = ({ label, error, value, type, placeholder, maxLength, onChange }) => {
    return (
        <div className={styles.gridCol}>

            <div className={styles.formField}>
                <label className={styles.formFieldLabel}>
                    {label}
                </label>
                <MyInput
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

export default React.memo(MyModalInput);
