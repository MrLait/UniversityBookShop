// @ts-nocheck
import React from 'react';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { routePaths } from '../../../router/routes';
import styles from './Header.module.css'
// className={styles.header}
const Header = () => {
    return (
        <div className={styles.header}>
            <div className={styles.inner}>
                {/* <Navbar bg="light" variant="light" > */}
                <div className={styles.headerMain}>
                    <Nav.Link href={routePaths.Universities}> Home </Nav.Link>
                    <div className={styles.headerBlank}></div>
                    <div className={styles.headerMainRight}>
                        <Nav.Link href="ToDo">ToDo</Nav.Link>
                    </div>
                </div>
                {/* </Navbar > */}
            </div>
        </div>

    );
}

export default Header;