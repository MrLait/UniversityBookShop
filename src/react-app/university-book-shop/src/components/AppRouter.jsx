// @ts-nocheck
import React from "react";
import { Navigate, Route } from "react-router";
import { Routes } from "react-router-dom";
import { routePaths, routes } from "../router/routes";

const AppRouter = () => {
    return (
        <div>
            <Routes>
                {routes.map(route =>
                    <Route key={route.path} path={route.path} element={<route.element />} />
                )}
                <Route path="*" element={< Navigate to={routePaths.Universities} />} />
            </Routes>
        </div>
    )
}
export default AppRouter;