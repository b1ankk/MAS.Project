import axios from 'axios';
import { useEffect, useState } from 'react';
import ServiceTimeSlot from '../model/serviceTimeSlot.ts';
import ServiceTimeSlotFormatter from '../util/ServiceTimeSlotFormatter.ts';

const MainPage = () => {
    const [upcomingServices, setUpcomingServices] = useState<ServiceTimeSlot[]>();

    useEffect(() => {
        axios
            .get('serviceTimeSlots/upcoming')
            .then(response => {
                setUpcomingServices(response.data as ServiceTimeSlot[]);
            })
            .catch(e => console.log(e));
    }, []);

    return (
        <div>
            <h1 className="display-6 py-2">Upcoming services</h1>
            {upcomingServices?.length === 0 && <p> There is nothing here :(</p>}
            {upcomingServices && upcomingServices?.length > 0 && (
                <table className="table table-hover table-striped">
                    <thead>
                        <tr className="h5">
                            <th>Service name</th>
                            <th>Date</th>
                            <th>Time</th>
                            <th>Specialist</th>
                            <th>Cost</th>
                        </tr>
                    </thead>
                    <tbody className="table-group-divider">
                        {upcomingServices
                            ?.map(
                                serviceTimeSlot =>
                                    [
                                        serviceTimeSlot,
                                        new ServiceTimeSlotFormatter(serviceTimeSlot),
                                    ] as [ServiceTimeSlot, ServiceTimeSlotFormatter]
                            )
                            .map(([slot, formatter]) => (
                                <tr key={slot.id}>
                                    <td className="col-3">{formatter.getServiceName()}</td>
                                    <td className="col-3">{formatter.getLocalizedStartDate()}</td>
                                    <td className="col-2">
                                        {formatter.getLocalizedStartTime()}
                                        {' - '}
                                        {formatter.getLocalizedEndTime()}
                                    </td>
                                    <td className="col-3">{formatter.getLastAndFirstNames()}</td>
                                    <td className="col-1">{formatter.getLocalizedPrice()}</td>
                                </tr>
                            ))}
                    </tbody>
                </table>
            )}
        </div>
    );
};

export default MainPage;
