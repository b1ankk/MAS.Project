import { Outlet } from 'react-router-dom';
import './MainLayout.css';

export const MainLayout = () => {
    return (
        <>
            <div className="modal fade" id="bookServiceModal" tabIndex={-1}>
                <div className="modal-dialog modal-dialog-centered">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h1 className="modal-title h4">Book a service</h1>
                            <button
                                className="btn-close"
                                type="button"
                                data-bs-dismiss="modal"
                            ></button>
                        </div>
                        <div className="modal-body">
                            <form action="">
                                <div className="row mb-3">
                                    <label
                                        htmlFor="TODO"
                                        className="col-sm-3 col-form-label"
                                    >
                                        Service:
                                    </label>
                                    <div className="col-sm">
                                        <select className="form-select">
                                            <option selected value="@null">
                                                Choose a service
                                            </option>
                                        </select>
                                    </div>
                                </div>
                                <div className="row mb-3">
                                    <label
                                        htmlFor="TODO"
                                        className="col-sm-3 col-form-label"
                                    >
                                        Specialist:
                                    </label>
                                    <div className="col-sm">
                                        <select className="form-select">
                                            <option selected value="@null">
                                                Choose a specialist
                                            </option>
                                        </select>
                                    </div>
                                </div>
                                <div className="row mb-3">
                                    <label
                                        htmlFor="TODO"
                                        className="col-sm-3 col-form-label"
                                    >
                                        Date range:
                                    </label>
                                    <div className="col-sm">
                                        <div className="input-group">
                                            <input
                                                type="date"
                                                className="form-control"
                                            />
                                            <span className="input-group-text">
                                                <i className="bi bi-arrow-right-short"></i>
                                            </span>
                                            <input
                                                type="date"
                                                className="form-control"
                                            />
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <div className="modal-footer">
                            <button
                                className="btn btn-secondary"
                                type="button"
                                data-bs-dismiss="modal"
                            >
                                Close
                            </button>
                            <button className="btn btn-primary" type="button">
                                Search
                            </button>
                        </div>
                    </div>
                </div>
            </div>

            <header>
                <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
                    <div className="container">
                        <a className="navbar-brand">Health Clinic</a>
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
                                    <a className="nav-link text-dark">Home</a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link text-dark">
                                        Previous Visits
                                    </a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link text-dark">
                                        Pricing
                                    </a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link text-dark">About</a>
                                </li>
                                <li className="nav-item">
                                    <a className="nav-link text-dark">
                                        Contact Us
                                    </a>
                                </li>
                                <li className="nav-item">
                                    <button
                                        className="btn btn-primary"
                                        type="button"
                                        data-bs-toggle="modal"
                                        data-bs-target="#bookServiceModal"
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
                    &copy; 2023 - Health Clinic - MAS Project - <a>Privacy</a>
                </div>
            </footer>
        </>
    );
};
