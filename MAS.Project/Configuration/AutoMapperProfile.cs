using AutoMapper;
using MAS.Project.DTOs;
using MAS.Project.Model;

namespace MAS.Project.Configuration;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() {
        CreateMap<ServiceType, ServiceTypeWithAuthorizedDto>();
        CreateMap<MedicalWorker, ServiceTypeWithAuthorizedDto.MedicalWorker>();
    }
}
