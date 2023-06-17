import { SnackbarProvider } from 'notistack';
import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom';
import ServiceBookedSnackbar from './components/ServiceBookedSnackbar.tsx';
import ServiceSearchContext from './context/ServiceSearchContext.tsx';
import { MainLayout } from './layout/MainLayout.tsx';
import MainPage from './page-content/MainPage.tsx';
import Services from './page-content/Services.tsx';

const App = () => {
    return (
        <SnackbarProvider
            Components={{
                bookedSuccessfully: ServiceBookedSnackbar,
            }}
            anchorOrigin={{
                horizontal: 'center',
                vertical: 'top',
            }}
        >
            <ServiceSearchContext.Provider value={{}}>
                <BrowserRouter>
                    <Routes>
                        <Route path="/" element={<MainLayout />}>
                            <Route path="/" element={<MainPage />} />
                            <Route path="/services" element={<Services />} />
                        </Route>

                        <Route path="*" element={<Navigate to="/" />} />
                    </Routes>
                </BrowserRouter>
            </ServiceSearchContext.Provider>
        </SnackbarProvider>
    );
};

export default App;
