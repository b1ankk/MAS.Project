using MAS.Project.Model;

namespace MAS.Project.Repositories;

public interface IServiceTypeRepository
{
    Task<IList<ServiceType>> GetAllServiceTypesWithAuthorizedMedicalWorkersAsync();
}
