import axios from 'axios';
import { useSnackbar } from 'notistack';
import { Button, Modal } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import ServiceTimeSlot from '../model/serviceTimeSlot.ts';
import ServiceTimeSlotFormatter from '../util/ServiceTimeSlotFormatter.ts';

type Props = {
    show: boolean;
    serviceName?: string;
    serviceTimeSlot?: ServiceTimeSlot;
    handleClose: () => void;
};

const BookServiceTimeSlotModal = (props: Props) => {
    const { enqueueSnackbar } = useSnackbar();
    const navigate = useNavigate();

    if (props.serviceTimeSlot == null) return <div></div>;

    const serviceTimeSlotFormatter = new ServiceTimeSlotFormatter(props.serviceTimeSlot);

    const bookService = () => {
        axios
            .post(`serviceTimeSlots/${props.serviceTimeSlot?.id ?? ''}/book`)
            .then(() => {
                onBookSuccessful();
            })
            .catch(e => console.log(e));
    };

    const onBookSuccessful = () => {
        enqueueSnackbar('Service booked successfully!', {
            variant: 'bookedSuccessfully',
        });
        props.handleClose();
        navigate('/');
    };

    return (
        <Modal show={props.show} onHide={props.handleClose}>
            <Modal.Header closeButton>
                <Modal.Title className="h4">Book a service</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <div className="row mb-3">
                    <span className="col-4 fs-5">Service:</span>
                    <span className="col fs-5 text-secondary">
                        {serviceTimeSlotFormatter.getServiceName()}
                    </span>
                </div>
                <div className="row mb-3">
                    <span className="col-4 fs-5">Date and time:</span>
                    <span className="col fs-5 text-secondary">
                        {serviceTimeSlotFormatter.getLocalizedTimeSpan()}
                    </span>
                </div>
                <div className="row mb-3">
                    <span className="col-4 fs-5">Specialist:</span>
                    <span className="col fs-5 text-secondary">
                        {serviceTimeSlotFormatter.getLastAndFirstNames()}
                    </span>
                </div>
                <div className="row mb-3">
                    <span className="col-4 fs-5">Price:</span>
                    <span className="col fs-5 text-secondary">
                        {serviceTimeSlotFormatter.getLocalizedPrice()}
                    </span>
                </div>
                <div className="row mb-3">
                    <div className="fs-5">Recommendations before the service:</div>
                    <div className="fs-5 text-secondary">
                        {serviceTimeSlotFormatter.getRecommendations()}
                    </div>
                </div>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={props.handleClose}>
                    Cancel
                </Button>
                <Button variant="primary" onClick={bookService}>
                    Book the service
                </Button>
            </Modal.Footer>
        </Modal>
    );
};

export default BookServiceTimeSlotModal;
