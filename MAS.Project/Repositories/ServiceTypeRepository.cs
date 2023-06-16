using MAS.Project.Model;
using Microsoft.EntityFrameworkCore;

namespace MAS.Project.Repositories;

public class ServiceTypeRepository : RepositoryBase, IServiceTypeRepository
{
    public async Task<IList<ServiceType>> GetAllServiceTypesWithAuthorizedMedicalWorkersAsync() {
        return await DbContext
            .ServiceType
            .Include(st => st.AuthorizedMedicalWorkers
                .OrderBy(mw => mw.LastName)
                .ThenBy(mw => mw.FirstName))
            .ToListAsync();
    }
}
