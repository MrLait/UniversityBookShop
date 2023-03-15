// @ts-nocheck
import React from 'react'
import styles from './MyModal.module.css';
const MyModal = ({ children, show, setShow }) => {
    const rootStyles = [styles.myModal]
    if (show) {
        rootStyles.push(styles.active);
    }
    return (
        <div className={rootStyles.join(' ')} onClick={() => setShow(false)} >
            <div className={styles.myModalContent} onClick={(e) => e.stopPropagation()}>
                {children}
            </div>
        </div >
    )
}

export default MyModal
