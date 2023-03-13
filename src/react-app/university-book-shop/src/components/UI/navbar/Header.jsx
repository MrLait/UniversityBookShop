import React from 'react';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { routePaths } from '../../../router/routes';

const Header = () => {
    return (
        <>
            <Navbar bg="light" variant="light">
                <Nav className="me-auto">
                    <Nav.Link href={routePaths.Universities} >Universities</Nav.Link>
                    <Nav.Link href="ToDo">ToDo</Nav.Link>
                </Nav>
            </Navbar>
        </>
    );
}

export default Header;