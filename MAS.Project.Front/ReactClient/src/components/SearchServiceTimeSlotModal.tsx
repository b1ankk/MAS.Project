import axios from 'axios';
import { ChangeEvent, useContext, useEffect, useRef, useState } from 'react';
import { Button, Form, Modal, Row } from 'react-bootstrap';
import { Link, createSearchParams } from 'react-router-dom';
import ServiceSearchContext from '../context/ServiceSearchContext.tsx';
import ServiceTypeWithAuthorized from '../model/serviceTypeWithAuthorized.ts';

type Props = {
    show: boolean;
    handleClose?: () => void;
};

export const SearchServiceTimeSlotModal = (props: Props) => {
    const searchContext = useContext(ServiceSearchContext);

    const serviceTypes = useRef<ServiceTypeWithAuthorized[]>();
    const [selectedServiceTypeId, setSelectedServiceTypeId] =
        useState<string>();
    const [selectedMedicalWorkerId, setSelectedMedicalWorkerId] =
        useState<string>();
    const [dateFrom, setDateFrom] = useState<string>();
    const [dateTo, setDateTo] = useState<string>();

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

    const onServiceChange = (e: ChangeEvent<HTMLSelectElement>) => {
        const id = e.target.value;
        setSelectedServiceTypeId(id);
        setSelectedMedicalWorkerId('');
        searchContext.serviceName = serviceTypes.current?.find(
            x => x.id.toString() === id
        )?.name;
    };

    return (
        <Modal show={props.show} onHide={props.handleClose} centered>
            <Modal.Header closeButton>
                <Modal.Title className="h4">Book a service</Modal.Title>
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
                                onChange={onServiceChange}
                            >
                                <option value="">Choose a service</option>
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
                                disabled={shouldDisableFields()}
                                value={selectedMedicalWorkerId}
                                onChange={e => setSelectedMedicalWorkerId(e.target.value)}
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
                                    value={dateFrom}
                                    onChange={e => setDateFrom(e.target.value)}
                                />
                                <span className="input-group-text">
                                    <i className="bi bi-arrow-right-short"></i>
                                </span>
                                <input
                                    type="date"
                                    className="form-control"
                                    disabled={shouldDisableFields()}
                                    value={dateTo}
                                    onChange={e => setDateTo(e.target.value)}
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
                <Link
                    to={{
                        pathname: 'services',
                        search: createSearchParams({
                            serviceTypeId: selectedServiceTypeId!,
                            medicalWorkerId: selectedMedicalWorkerId ?? '',
                            dateFrom: dateFrom ?? '',
                            dateTo: dateTo ?? '',
                        }).toString(),
                    }}
                >
                    <Button
                        variant="primary"
                        onClick={props.handleClose}
                        disabled={shouldDisableFields()}
                    >
                        Search
                    </Button>
                </Link>
            </Modal.Footer>
        </Modal>
    );
};

export default SearchServiceTimeSlotModal;
