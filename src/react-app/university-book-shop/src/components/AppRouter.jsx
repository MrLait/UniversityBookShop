// @ts-nocheck
import React from "react";
import { Navigate, Route } from "react-router";
import { Routes, useLocation } from "react-router-dom";
import { routePaths, routes } from "../router/routes";
import { CSSTransition, TransitionGroup, SwitchTransition } from 'react-transition-group'

const AppRouter = () => {
    const location = useLocation();
    var pathName = location.pathname;
    const components = pathName.split('/');
    if (components.length > 1) {
        pathName = components[1];
    }

    return (
        <>
            <TransitionGroup>
                <CSSTransition
                    timeout={500}
                    classNames='page'
                    key={pathName}
                    unmountOnExit
                >
                    <Routes>
                        {routes.map(route =>
                            <Route key={route.path} path={route.path} element={<route.element />} />
                        )}
                        <Route path="*" element={< Navigate to={routePaths.Universities} />} />
                    </Routes >
                </CSSTransition>
            </TransitionGroup >
        </>
    )
}
export default AppRouter;