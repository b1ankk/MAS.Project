using MAS.Project.Model;
using MAS.Project.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MAS.Project.Repositories;

public class ServiceTypeRepository : RepositoryBase, IServiceTypeRepository
{
    public ServiceTypeRepository(AppDbContext dbContext)
        : base(dbContext) { }

    public async Task<IList<ServiceType>> GetAllServiceTypesWithAuthorizedMedicalWorkersAsync() {
        return await DbContext
            .ServiceType
            .Include(st => st.AuthorizedMedicalWorkers
                .OrderBy(mw => mw.Parent.LastName)
                .ThenBy(mw => mw.Parent.FirstName))
            .ThenInclude(x => x.Parent)
            .ToListAsync();
    }
}
