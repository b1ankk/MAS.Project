using MAS.Project.Persistence;

namespace MAS.Project.Repositories;

public abstract class RepositoryBase
{
    public required AppDbContext DbContext { get; init; }
}
