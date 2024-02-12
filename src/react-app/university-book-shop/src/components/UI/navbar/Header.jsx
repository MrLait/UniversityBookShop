// @ts-nocheck
import React, { useEffect, useState } from 'react'
import { useLocation } from 'react-router-dom';
import Nav from 'react-bootstrap/Nav';
import { routePaths } from '../../../router/routes';
import styles from './Header.module.css'
const Header = () => {
    const pathname = useLocation().pathname

    const routesToMatch = [
        routePaths.Home,
        routePaths.Universities,
        routePaths.PageIndex
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
                    <Nav.Link className={`${styles.headerMainLeft} ${styles.title}`} href={routePaths.Home} >
                        University book shop app
                    </Nav.Link>
                    <div className={styles.headerBlank}></div>
                    <div className={styles.headerMainRight}>
                        <Nav.Link className={styles.title} href={routePaths.Home}>
                            Home
                        </Nav.Link>
                        {/* <Nav.Link className={styles.title} href="ToDo">
                            ToDo
                        </Nav.Link> */}
                    </div>
                </div>
            </div>
        </div>

    );
}

export default Header;