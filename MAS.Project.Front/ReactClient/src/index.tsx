import axios from 'axios';
import 'bootstrap-icons/font/bootstrap-icons.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import React from 'react';
import ReactDOM from 'react-dom/client';
import 'normalize.css';
import App from './App.tsx';
import { URL_BASE } from './constants.ts';
import './index.css';

axios.interceptors.request.use(conf => {
    conf.baseURL = URL_BASE;
    return conf;
});

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
    <React.StrictMode>
        <App />
    </React.StrictMode>
);
