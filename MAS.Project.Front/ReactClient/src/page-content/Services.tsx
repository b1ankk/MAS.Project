import axios from 'axios';
import { useContext, useEffect, useState } from 'react';
import { useSearchParams } from 'react-router-dom';
import ServiceSearchContext from '../context/ServiceSearchContext.tsx';
import ServiceTimeSlot from '../model/serviceTimeSlot.ts';

const timeFormatOptions: Intl.DateTimeFormatOptions = {
    hour: '2-digit',
    minute: '2-digit',
    hour12: false,
};
const dateFormatOptions: Intl.DateTimeFormatOptions = {
    dateStyle: 'full',
};

const Services = () => {
    const searchContext = useContext(ServiceSearchContext);

    const [searchParams, setSearchParams] = useSearchParams();
    const [serviceTimeSlots, setServiceTimeSlots] =
        useState<ServiceTimeSlot[]>();

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

    const displayMedicalWorkersList = (serviceTimeslot: ServiceTimeSlot) => {
        return serviceTimeslot.service.medicalWorkersConducting
            .map(mw => `${mw.lastName} ${mw.firstName}`)
            .join(', ');
    };

    return (
        <>
            <div>
                <h1 className="display-6 py-2">
                    Available time slots - {searchContext.serviceName}
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
                        {serviceTimeSlots?.map(serviceTimeSlot => (
                            <tr key={serviceTimeSlot.id}>
                                <td className="col-3">
                                    {new Date(
                                        serviceTimeSlot.start
                                    ).toLocaleDateString(
                                        undefined,
                                        dateFormatOptions
                                    )}
                                </td>
                                <td  className="col-3">
                                    {new Date(
                                        serviceTimeSlot.start
                                    ).toLocaleTimeString(
                                        undefined,
                                        timeFormatOptions
                                    )}
                                    {' - '}
                                    {new Date(
                                        serviceTimeSlot.end
                                    ).toLocaleTimeString(
                                        undefined,
                                        timeFormatOptions
                                    )}
                                </td>
                                <td  className="col-3">
                                    {displayMedicalWorkersList(serviceTimeSlot)}
                                </td>
                                <td className="col-2">
                                    {serviceTimeSlot.service.price.toLocaleString(
                                        undefined,
                                        {
                                            style: 'currency',
                                            currency: 'USD',
                                            currencyDisplay: 'symbol',
                                        }
                                    )}
                                </td>
                                <td className="col-1">
                                    <a
                                        className="btn btn-link py-0"
                                        data-bs-toggle="modal"
                                        data-bs-target="#bookModal"
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
