import Entity from './entity.ts';
import Service from './service.ts';

interface ServiceTimeSlot extends Entity {
    start: string;
    end: string;
    
    service: Service;
}

export default ServiceTimeSlot;
