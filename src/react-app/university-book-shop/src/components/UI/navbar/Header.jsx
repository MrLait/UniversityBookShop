// @ts-nocheck
import React from 'react';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { routePaths } from '../../../router/routes';
import styles from './Header.module.css'
const Header = () => {
    return (
        <div className={styles.header}>
            <div className={styles.inner}>
                <div className={styles.headerMain}>
                    <div className={styles.headerMainLeft} >
                        University book shop app
                    </div>
                    <div className={styles.headerBlank}></div>
                    <div className={styles.headerMainRight}>
                        <Nav.Link className={styles.title} href={routePaths.Universities}>
                            Home
                        </Nav.Link>
                        <Nav.Link className={styles.title} href="ToDo">
                            ToDo
                        </Nav.Link>
                    </div>
                </div>
            </div>
        </div>

    );
}

export default Header;