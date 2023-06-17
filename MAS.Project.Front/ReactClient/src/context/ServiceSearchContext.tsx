import { createContext } from 'react';

export interface IServiceSearchContext {
    serviceName?: string;
}

const ServiceSearchContext = createContext<IServiceSearchContext>({});

export default ServiceSearchContext;
