import Entity from './entity.ts';

interface ServiceType extends Entity {
    name: string;
    minDuration?: string;
    maxDuration?: string;
    minStartTime?: string;
    maxStartTime?: string;
    recommendationsBeforeService?: string;
}

export default ServiceType;
