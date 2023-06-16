import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom';
import { MainLayout } from './layout/MainLayout.tsx';
import MainPage from './page-content/MainPage.tsx';
import Services from './page-content/Services.tsx';

const App = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<MainLayout />}>
                    <Route path="/" element={<MainPage />} />
                    <Route path="/services" element={<Services />} />
                </Route>

                <Route path="*" element={<Navigate to="/" />} />
            </Routes>
        </BrowserRouter>
    );
};

export default App;
