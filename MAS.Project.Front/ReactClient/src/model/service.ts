import Entity from './entity.ts';
import MedicalWorker from './medicalWorker.ts';

interface Service extends Entity {
    price: number;
    duration: string;
    
    medicalWorkersConducting: MedicalWorker[];
}

export default Service;
