const Services = () => {
    return (
        <>
            <div className="modal fade" id="bookModal" tabIndex={-1}>
                <div className="modal-dialog modal-dialog-centered">
                    <div className="modal-content">
                        <div className="modal-header">
                            <h1 className="modal-title h4">Service details</h1>
                            <button
                                type="button"
                                className="btn-close"
                                data-bs-dismiss="modal"
                                aria-label="Close"
                            ></button>
                        </div>
                        <div className="modal-body">
                            <div className="row mb-3">
                                <span className="col-4 fs-5">Service:</span>
                                <span className="col fs-5 text-secondary">
                                    Blood test
                                </span>
                            </div>
                            <div className="row mb-3">
                                <span className="col-4 fs-5">
                                    Date and time:
                                </span>
                                <span className="col fs-5 text-secondary">
                                    23.01.2020 13:45-14:00
                                </span>
                            </div>
                            <div className="row mb-3">
                                <span className="col-4 fs-5">Specialist:</span>
                                <span className="col fs-5 text-secondary">
                                    John Smith
                                </span>
                            </div>
                            <div className="row mb-3">
                                <span className="col-4 fs-5">Price:</span>
                                <span className="col fs-5 text-secondary">
                                    $123.00
                                </span>
                            </div>
                            <div className="row mb-3">
                                <div className="fs-5">
                                    Recommendations before the service:
                                </div>
                                <div className="fs-5 text-secondary">
                                    Nothing here...
                                </div>
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button
                                type="button"
                                className="btn btn-secondary"
                                data-bs-dismiss="modal"
                            >
                                Close
                            </button>
                            <button type="button" className="btn btn-primary">
                                Book the service
                            </button>
                        </div>
                    </div>
                </div>
            </div>

            <div>
                <h1 className="display-6 py-2">
                    Available time slots - [Service name]
                </h1>
                <table className="table table-hover">
                    <thead>
                        <tr className="h5">
                            <th>Date</th>
                            <th>Time</th>
                            <th>Specialist</th>
                            <th>Cost</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody className="table-group-divider">
                        <tr>
                            <td>23.01.2020</td>
                            <td>12:30 - 13:00</td>
                            <td>John Smith</td>
                            <td>$123</td>
                            <td>
                                <a
                                    className="btn btn-link py-0"
                                    data-bs-toggle="modal"
                                    data-bs-target="#bookModal"
                                >
                                    Book
                                </a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </>
    );
};

export default Services;
