// @ts-nocheck
import { createContext, useState } from 'react';

const AuthContext = createContext({});

export const AuthProvider = ({ children }) => {
    const [isRememberMe, setIsRememberMe] = useState(JSON.parse(localStorage.getItem('isRememberMe')) || false);
    const [auth, setAuth] = useState({
        accessToken: isRememberMe ? (localStorage.getItem('accessToken')) || null : null,
        isAuth: (localStorage.getItem('isAuth')) || false,
    });

    return (
        <AuthContext.Provider value={{ auth, setAuth, isRememberMe, setIsRememberMe }}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthContext;