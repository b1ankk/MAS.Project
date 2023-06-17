import Entity from './entity.ts';

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

export interface MedicalWorker extends Entity {
    firstName: string;
    lastName: string;
}

