import axios from 'axios';
import { useContext, useEffect, useRef, useState } from 'react';
import { useSearchParams } from 'react-router-dom';
import BookServiceTimeSlotModal from '../components/BookServiceTimeSlotModal.tsx';
import ServiceSearchContext from '../context/ServiceSearchContext.tsx';
import ServiceTimeSlot from '../model/serviceTimeSlot.ts';
import ServiceTimeSlotFormatter from '../util/ServiceTimeSlotFormatter.ts';

const Services = () => {
    const searchContext = useContext(ServiceSearchContext);

    const [searchParams, setSearchParams] = useSearchParams();
    const [serviceTimeSlots, setServiceTimeSlots] = useState<ServiceTimeSlot[]>();
    const [bookModalShown, setBookModalShown] = useState(false);
    const chosenServiceTimeSlot = useRef<ServiceTimeSlot>();

    useEffect(() => {
        const serviceTypeId = searchParams.get('serviceTypeId');
        const medicalWorkerId = searchParams.get('medicalWorkerId');
        const dateFrom = searchParams.get('dateFrom');
        const dateTo = searchParams.get('dateTo');

        axios
            .get('serviceTimeSlots', {
                params: {
                    serviceTypeId,
                    medicalWorkerId,
                    dateFrom,
                    dateTo,
                },
            })
            .then(response => {
                setServiceTimeSlots(response.data as ServiceTimeSlot[]);
            })
            .catch(e => console.log(e));
    }, [searchParams]);

    const showBookModal = (serviceTimeSlot: ServiceTimeSlot) => {
        chosenServiceTimeSlot.current = serviceTimeSlot;
        setBookModalShown(true);
    };

    return (
        <>
            <BookServiceTimeSlotModal
                show={bookModalShown}
                serviceName={searchContext.serviceName}
                serviceTimeSlot={chosenServiceTimeSlot.current}
                handleClose={() => setBookModalShown(false)}
            />
            <div>
                <h1 className="display-6 py-2">
                    Available time slots: {' '}
                    <span className="fw-bolder">
                        {searchContext.serviceName ??
                         serviceTimeSlots?.at(0)?.service?.serviceType.name}
                    </span>
                </h1>
                <table className="table table-hover table-striped">
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
                        {serviceTimeSlots
                            ?.map(
                                serviceTimeSlot =>
                                    [
                                        serviceTimeSlot,
                                        new ServiceTimeSlotFormatter(serviceTimeSlot),
                                    ] as [ServiceTimeSlot, ServiceTimeSlotFormatter]
                            )
                            .map(([slot, formatter]) => (
                                <tr key={slot.id}>
                                    <td className="col-3">{formatter.getLocalizedStartDate()}</td>
                                    <td className="col-3">
                                        {formatter.getLocalizedStartTime()}
                                        {' - '}
                                        {formatter.getLocalizedEndTime()}
                                    </td>
                                    <td className="col-3">{formatter.getLastAndFirstNames()}</td>
                                    <td className="col-2">{formatter.getLocalizedPrice()}</td>
                                    <td className="col-1">
                                        <a
                                            className="btn btn-link py-0"
                                            onClick={() => showBookModal(slot)}
                                        >
                                            Book
                                        </a>
                                    </td>
                                </tr>
                            ))}
                    </tbody>
                </table>
            </div>
        </>
    );
};

export default Services;
