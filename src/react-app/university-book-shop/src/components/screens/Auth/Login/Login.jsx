// @ts-nocheck
import React, { useState } from 'react';

// import MyButton from '../../../UI/button/MyButton';
import MyModal from '../../../UI/modal/MyModal';

import LoginForm from './LoginForm';

import styles from './Login.module.css';

const Login = () => {
    const [modalShow, setModalShow] = useState(false);

    return (
        <>
            <div className={styles.title} onClick={setModalShow}>
                Log in
            </div>
            <MyModal modalShow={modalShow} setModalShow={setModalShow}>
                <LoginForm
                    modalShow={modalShow}
                    setModalShow={setModalShow}
                />
            </MyModal>
        </>
    );
};

export default React.memo(Login);