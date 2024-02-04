// @ts-nocheck
import React from 'react'
import styles from './MyInput.module.css'

const MyInput = ({ error, ...props }) => {
    console.log(styles.message)
    var rootStyles = [styles.textInput];
    if (error) {
        rootStyles.push(styles.borderColorError)
    }
    return (
        <>
            <input className={rootStyles.join(' ')} {...props} />
            {error && <div className={styles.message}>{error}</div>}
        </>
    )
}

export default MyInput
