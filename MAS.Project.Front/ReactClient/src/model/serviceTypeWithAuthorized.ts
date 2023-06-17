import Entity from './entity.ts';
import { MedicalWorker } from './medicalWorker.ts';

interface ServiceTypeWithAuthorized extends Entity {
    name: string;
    minDuration?: string;
    maxDuration?: string;
    minStartTime?: string;
    maxStartTime?: string;
    recommendationsBeforeService?: string;

    authorizedMedicalWorkers: MedicalWorker[];
}
export default ServiceTypeWithAuthorized;
