import axios from 'axios';
import { useEffect, useRef, useState } from 'react';
import { Button, Form, Modal, Row } from 'react-bootstrap';
import ServiceTypeWithAuthorized from '../model/serviceTypeWithAuthorized.ts';
import { Link } from 'react-router-dom';

type Props = {
    show: boolean;
    handleClose?: () => void;
};

export const BookServiceModal = (props: Props) => {
    const serviceTypes = useRef<ServiceTypeWithAuthorized[]>();
    const [selectedServiceTypeId, setSelectedServiceTypeId] =
        useState<string>();

    useEffect(() => {
        axios
            .get('/servicetypes')
            .then(response => {
                serviceTypes.current =
                    response.data as ServiceTypeWithAuthorized[];
            })
            .catch(e => console.log(e));
    }, []);

    const shouldDisableFields = () => {
        return selectedServiceTypeId == null || selectedServiceTypeId === '';
    };

    return (
        <Modal show={props.show} onHide={props.handleClose} centered>
            <Modal.Header closeButton>
                <Modal.Title>Book a service</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form>
                    <Row className="mb-3">
                        <Form.Label className="col-sm-3 col-form-label">
                            Service:
                        </Form.Label>
                        <div className="col-sm">
                            <Form.Select
                                value={selectedServiceTypeId}
                                onChange={e =>
                                    setSelectedServiceTypeId(e.target.value)
                                }
                            >
                                <option value="">
                                    Choose a service
                                </option>
                                {serviceTypes.current?.map(serviceType => (
                                    <option
                                        key={serviceType.id}
                                        value={serviceType.id}
                                    >
                                        {serviceType.name}
                                    </option>
                                ))}
                            </Form.Select>
                        </div>
                    </Row>
                    <Row className="mb-3">
                        <Form.Label className="col-sm-3 col-form-label">
                            Specialist:
                        </Form.Label>
                        <div className="col-sm">
                            <Form.Select
                                defaultValue=""
                                disabled={shouldDisableFields()}
                            >
                                <option value="">Choose a specialist</option>
                                {serviceTypes.current
                                    ?.find(
                                        st =>
                                            st.id.toString() ===
                                            selectedServiceTypeId
                                    )
                                    ?.authorizedMedicalWorkers?.map(
                                        medicalWorker => (
                                            <option
                                                key={medicalWorker.id}
                                                value={medicalWorker.id}
                                            >
                                                {`${medicalWorker.lastName} ${medicalWorker.firstName}`}
                                            </option>
                                        )
                                    )}
                            </Form.Select>
                        </div>
                    </Row>
                    <Row className="mb-3">
                        <Form.Label className="col-sm-3 col-form-label">
                            Date range:
                        </Form.Label>
                        <div className="col-sm">
                            <div className="input-group">
                                <input
                                    type="date"
                                    className="form-control"
                                    disabled={shouldDisableFields()}
                                />
                                <span className="input-group-text">
                                    <i className="bi bi-arrow-right-short"></i>
                                </span>
                                <input
                                    type="date"
                                    className="form-control"
                                    disabled={shouldDisableFields()}
                                />
                            </div>
                        </div>
                    </Row>
                </Form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={props.handleClose}>
                    Cancel
                </Button>
                <Link to="/services">
                    <Button variant="primary" onClick={props.handleClose} disabled={shouldDisableFields()}>
                        Search
                    </Button>
                </Link>
            </Modal.Footer>
        </Modal>
    );
};

export default BookServiceModal;
