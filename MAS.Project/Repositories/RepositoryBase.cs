using MAS.Project.Persistence;

namespace MAS.Project.Repositories;

public abstract class RepositoryBase
{
    protected readonly AppDbContext DbContext;

    protected RepositoryBase(AppDbContext dbContext) {
        DbContext = dbContext;
    }
}
