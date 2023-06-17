using AutoMapper;
using MAS.Project.DTOs;
using MAS.Project.Model;
using MedicalWorker = MAS.Project.Model.MedicalWorker;

namespace MAS.Project.Configuration;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() {
        CreateMap<ServiceType, ServiceTypeWithAuthorizedDto>();
        CreateMap<MedicalWorker, MedicalWorkerDto>();
        CreateMap<ServiceTimeSlot, BookableServiceTimeSlotDto>();
        CreateMap<Service, ServiceWithConductingDto>();
    }
}
