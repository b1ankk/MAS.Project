import Entity from './entity.ts';
import MedicalWorker from './medicalWorker.ts';
import ServiceType from './ServiceType.ts';

interface Service extends Entity {
    price: number;
    duration: string;
    
    serviceType: ServiceType;
    medicalWorkersConducting: MedicalWorker[];
}

export default Service;
