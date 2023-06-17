using AutoMapper;
using MAS.Project.DTOs;
using MAS.Project.Model;
using MedicalWorker = MAS.Project.Model.MedicalWorker;

namespace MAS.Project.Configuration;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() {
        CreateMap<ServiceType, ServiceTypeWithAuthorizedDto>();
        CreateMap<ServiceType, ServiceTypeDto>();
        CreateMap<MedicalWorker, MedicalWorkerDto>();
        CreateMap<ServiceTimeSlot, ServiceTimeSlotDto>();
        CreateMap<Service, ServiceWithConductingDto>();
    }
}
