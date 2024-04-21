// @ts-nocheck
import React, { useState, useEffect } from 'react';

import MyModalSpinner from '../../../UI/spinner/MyModalSpinner/MyModalSpinner';

import useAuth, { usePostLoginMutation } from '../../../hooks/authHooks';

import MyModalLeftSection from '../../../UI/modal/MyModalLeftSection';
import MyModalInput from '../../../UI/modal/MyModalInput';

import { loginField } from '../../../constants/initialStates';

import MyModalButton from '../../../UI/modal/MyModalButton';

import styles from './LoginForm.module.css';

const LoginForm = ({ modalShow, setModalShow }) => {
    const { setAuth } = useAuth();
    const [login, setLogin] = useState(loginField);
    const [userNameError, setUserNameError] = useState('');
    const [passwordError, setPasswordError] = useState('');

    const postLoginMutation = usePostLoginMutation(setUserNameError, setPasswordError, setModalShow, setAuth);

    const postLoginHandler = (e) => {
        e.preventDefault();
        postLoginMutation.mutate([login.userName, login.password]);
    };

    useEffect(() => {
        if (modalShow) {
            setUserNameError('');
            setPasswordError('');
            setLogin(loginField);
        }
    }, [modalShow]);

    return (
        <div className={styles.root}>
            <div className={styles.contentTabs}>
                <MyModalSpinner isPending={postLoginMutation?.isPending} />
                <div className={styles.active}>
                    <div className={styles.container}>
                        <MyModalLeftSection />
                        <div className={styles.body}>
                            <div className={styles.inner}>
                                <h3 className={styles.title}>
                                    <strong>Log in</strong>
                                </h3>
                                <form>
                                    <div className={styles.grid}>
                                        <MyModalInput
                                            label="USERNAME (*)"
                                            error={userNameError}
                                            value={login.userName}
                                            onChange={e => setLogin({ ...login, userName: e.target.value })}
                                            type={'text'}
                                            placeholder={'UserName'}
                                            maxLength={150}
                                        />
                                        <MyModalInput
                                            label="PASSWORD (*)"
                                            error={passwordError}
                                            value={login.password}
                                            onChange={e => setLogin({ ...login, password: e.target.value })}
                                            type={'password'}
                                            placeholder={'Password'}
                                            maxLength={150}
                                        />
                                        <MyModalButton
                                            onClick={postLoginHandler}
                                            label="Log in"
                                        />
                                    </div>
                                </form>

                                <div className={styles.testCredentials}>
                                    <ul className={styles.list}>
                                        <p>
                                            Credential for test account:
                                        </p>
                                        <li>
                                            userName: vladimir
                                        </li>
                                        <li>
                                            password: Pass123$
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default React.memo(LoginForm);