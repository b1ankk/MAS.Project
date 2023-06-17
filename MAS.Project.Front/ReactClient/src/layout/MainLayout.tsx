import { useState } from 'react';
import { Link, Outlet } from 'react-router-dom';
import BookServiceModal from '../components/BookServiceModal.tsx';
import './MainLayout.css';

export const MainLayout = () => {
    const [showModal, setShowModal] = useState(false);

    return (
        <>
            <BookServiceModal
                show={showModal}
                handleClose={() => setShowModal(false)}
            />

            <header>
                <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
                    <div className="container">
                        <Link to="/" className="navbar-brand">
                            Health Clinic
                        </Link>
                        <button
                            className="navbar-toggler"
                            type="button"
                            data-bs-toggle="collapse"
                            data-bs-target=".navbar-collapse"
                            aria-controls="navbarSupportedContent"
                            aria-expanded="false"
                            aria-label="Toggle navigation"
                        >
                            <span className="navbar-toggler-icon"></span>
                        </button>
                        <div className="navbar-collapse collapse d-sm-inline-flex justify-content-between">
                            <ul className="navbar-nav flex-grow-1 d-flex gap-1">
                                <li className="nav-item">
                                    <Link to="/" className="nav-link text-dark">
                                        Home
                                    </Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="#" className="nav-link text-dark">
                                        Previous Visits
                                    </Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="#" className="nav-link text-dark">
                                        Pricing
                                    </Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="#" className="nav-link text-dark">
                                        About
                                    </Link>
                                </li>
                                <li className="nav-item">
                                    <Link to="#" className="nav-link text-dark">
                                        Contact Us
                                    </Link>
                                </li>
                                <li className="nav-item">
                                    <button
                                        className="btn btn-primary"
                                        type="button"
                                        onClick={() => setShowModal(true)}
                                    >
                                        Book a service
                                    </button>
                                </li>
                            </ul>
                        </div>
                    </div>
                </nav>
            </header>
            <div className="container">
                <main role="main" className="pb-3">
                    <Outlet />
                </main>
            </div>

            <footer className="border-top footer text-muted">
                <div className="container">
                    &copy; 2023 - Health Clinic - MAS Project -{' '}
                    <Link to="#">Privacy</Link>
                </div>
            </footer>
        </>
    );
};
