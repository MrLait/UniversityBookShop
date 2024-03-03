// @ts-nocheck
import React from 'react';
import { Navigate, Route } from 'react-router';
import { Routes, useLocation } from 'react-router-dom';

import { AnimatePresence } from 'framer-motion';

import { routePaths, routes } from '../router/routes';

const AppRouter = () => {
    const location = useLocation();

    return (
        <>
            <AnimatePresence mode="wait">
                <Routes location={location} key={location.pathname}>
                    {routes.map(route =>
                        <Route key={route.path} path={route.path} element={<route.element />} />
                    )}
                    <Route path="*" element={< Navigate to={routePaths.Universities} />} />
                </Routes >
            </AnimatePresence>
        </>
    );
};
export default AppRouter;