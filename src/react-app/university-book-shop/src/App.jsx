// @ts-nocheck
import React from 'react';
import { BrowserRouter } from 'react-router-dom';

import AppRouter from './components/AppRouter';
import Header from './components/UI/navbar/Header';
import styles from './App.module.css';
import Footer from './components/UI/footer/Footer';

function App() {
  return (
    <div className={styles.wrapper}>
      <BrowserRouter>
        <Header />
        <AppRouter />
        <Footer />
      </BrowserRouter>
    </div>
  );
}

export default App;
