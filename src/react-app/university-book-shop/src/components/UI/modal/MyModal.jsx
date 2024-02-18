// @ts-nocheck
import React from 'react';

import styles from './MyModal.module.css';
const MyModal = ({ children, modalShow, setModalShow }) => {
    const rootStyles = [styles.myModal];
    if (modalShow) {
        rootStyles.push(styles.active);
    }
    return (
        <div className={rootStyles.join(' ')} onClick={() => setModalShow(false)} >
            <div className={styles.myModalContent} onClick={(e) => e.stopPropagation()}>
                {children}
            </div>
        </div >
    );
};

export default MyModal;
