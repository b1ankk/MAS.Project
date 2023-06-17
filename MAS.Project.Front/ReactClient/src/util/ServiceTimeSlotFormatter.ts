import { DATE_FORMAT_OPTIONS, TIME_FORMAT_OPTIONS } from '../config.ts';
import ServiceTimeSlot from '../model/serviceTimeSlot.ts';

export default class ServiceTimeSlotFormatter {
    private serviceTimeSlot: ServiceTimeSlot;

    constructor(serviceTimeSlot: ServiceTimeSlot) {
        this.serviceTimeSlot = serviceTimeSlot;
    }

    getStartAsDate() {
        return new Date(this.serviceTimeSlot.start);
    }

    getEndAsDate() {
        return new Date(this.serviceTimeSlot.end);
    }

    getLocalizedStartDate() {
        return this.getStartAsDate().toLocaleDateString(undefined, DATE_FORMAT_OPTIONS);
    }
    
    getLocalizedStartDateNumeric() {
        return this.getStartAsDate().toLocaleDateString(undefined, {
            day: '2-digit',
            month: '2-digit',
            year: 'numeric'
        });
    }

    getLocalizedEndDate() {
        return this.getEndAsDate().toLocaleDateString(undefined, DATE_FORMAT_OPTIONS);
    }

    getLocalizedStartTime() {
        return this.getStartAsDate().toLocaleTimeString(undefined, TIME_FORMAT_OPTIONS);
    }
    getLocalizedEndTime() {
        return this.getEndAsDate().toLocaleTimeString(undefined, TIME_FORMAT_OPTIONS);
    }

    getLocalizedTimeSpan() {
        return (
            this.getLocalizedStartDateNumeric() +
            ' ' +
            this.getLocalizedStartTime() +
            '-' +
            this.getLocalizedEndTime()
        );
    }

    getLastAndFirstNames() {
        return this.serviceTimeSlot.service.medicalWorkersConducting
            .map(mw => `${mw.lastName} ${mw.firstName}`)
            .join(', ');
    }

    getLocalizedPrice() {
        return this.serviceTimeSlot.service.price.toLocaleString(undefined, {
            style: 'currency',
            currency: 'USD',
            currencyDisplay: 'symbol',
        });
    }

    getRecommendations() {
        return (
            this.serviceTimeSlot.service.serviceType.recommendationsBeforeService ??
            'Nothing here...'
        );
    }
    
    getServiceName() {
        return this.serviceTimeSlot.service.serviceType.name;
    }
}
