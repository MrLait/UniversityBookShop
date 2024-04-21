// @ts-nocheck
import React from 'react';

import useAuth from '../../../hooks/authHooks';

import styles from './Logout.module.css';

const Logout = () => {
    const { setAuth } = useAuth();
    const logoutHandler = () => {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('isAuth');
        localStorage.removeItem('isRememberMe');
        setAuth({});
    };
    return (
        <>
            <div className={styles.title}

                onClick={logoutHandler}
            >
                Log out
            </div>
        </>
    );
};

export default React.memo(Logout);