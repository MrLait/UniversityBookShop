// @ts-nocheck
import React from "react";
import { Navigate, Route } from "react-router";
import { Routes, useLocation } from "react-router-dom";
import { routePaths, routes } from "../router/routes";
import { AnimatePresence } from "framer-motion"

const AppRouter = () => {
    const location = useLocation();
    var searchName = location.search;
    const shouldAnimate = !searchName.includes('page');

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
    )
}
export default AppRouter;