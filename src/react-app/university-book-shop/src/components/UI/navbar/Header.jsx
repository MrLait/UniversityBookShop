import React from 'react';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { routePaths } from '../../../router/routes';

const Header = () => {
    return (
        <div style={{ background: '#e9e9e9' }}>
            <Navbar bg="light" variant="light" >
                <Nav className="me-auto">
                    <Nav.Link href={routePaths.Universities} >Universities</Nav.Link>
                    <Nav.Link href="ToDo">ToDo</Nav.Link>
                </Nav>
            </Navbar >

        </div>

    );
}

export default Header;