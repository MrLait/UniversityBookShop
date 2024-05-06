// @ts-nocheck
import React from 'react';
import ReactDOM from 'react-dom/client';

import { QueryClient, QueryClientProvider } from '@tanstack/react-query';

import './index.css';
import App from './App';
import { AuthProvider } from './components/contexts/AuthProvider';

const root = document.getElementById('root');
const queryClient = new QueryClient();

ReactDOM.createRoot(root).render(
    // <React.StrictMode>
    <QueryClientProvider client={queryClient}>
        <AuthProvider>
            <App />
        </AuthProvider>
    </QueryClientProvider>
    // </React.StrictMode>
);