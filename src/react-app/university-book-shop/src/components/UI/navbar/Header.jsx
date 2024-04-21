// @ts-nocheck
import React from 'react';
import { useLocation } from 'react-router-dom';

import Nav from 'react-bootstrap/Nav';

import { routePaths } from '../../../router/routes';
import transition from '../../../unitls/transition';

import Login from '../../screens/Auth/Login/Login';
import Logout from '../../screens/Auth/Logout/Logout';

import useAuth from '../../hooks/authHooks';

import styles from './Header.module.css';


const Header = () => {
    const { auth } = useAuth();
    const pathname = useLocation().pathname;
    const routesToMatch = [
        routePaths.Home,
        routePaths.Universities,
    ];

    const isMatchingRoute = routesToMatch.some((route) => {
        const regex = new RegExp(`^${route.replace(/:[^/]+/g, '[^/]+')}$`);
        return regex.test(pathname);
    });

    const headerStyle = isMatchingRoute
        ? styles.headerUniversities
        : styles.headerUniversity;

    return (
        <div className={`${styles.header} ${headerStyle}`}>
            <div className={styles.inner}>
                <div className={styles.headerMain}>
                    <Nav.Link className={`${styles.title}`} href={routePaths.Home} >
                        University book shop app
                    </Nav.Link>
                    <div className={styles.headerBlank}></div>
                    <div className={styles.headerMainRight}>
                        <Nav.Link className={styles.title} href={routePaths.Home}>
                            Home
                        </Nav.Link>
                        {auth?.isAuth
                            ?
                            <Logout />
                            :
                            <Login />
                        }
                        {/* <Nav.Link className={styles.title} href="ToDo">
                            ToDo
                        </Nav.Link> */}
                    </div>
                </div>
            </div>
        </div>

    );
};

export default transition(Header);