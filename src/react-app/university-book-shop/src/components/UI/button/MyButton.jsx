// @ts-nocheck
import React from 'react'
import styles from './MyButton.module.css'
const MyButton = ({ setStyles, children, ...props }) => {
    const additionalStyles = setStyles ? setStyles : '';
    const combinedStyles = `${styles.myBtn} ${additionalStyles}`;
    return (
        <button className={combinedStyles} {...props}>
            {children}
        </button >
    )
}

export default MyButton
