// @ts-nocheck
import React from "react";
import { BrowserRouter } from "react-router-dom";
import AppRouter from "./components/AppRouter";
import Header from "./components/UI/navbar/Header";
import styles from './App.module.css';

function App() {
  return (
    <div className={styles.app}>
      <BrowserRouter>
        <Header />
        <AppRouter />
      </BrowserRouter>
    </div>

  );
}

export default App;
