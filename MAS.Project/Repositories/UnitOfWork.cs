namespace MAS.Project.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IServiceTypeRepository serviceTypeRepository) {
        ServiceTypeRepository = serviceTypeRepository;
    }
    
    public IServiceTypeRepository ServiceTypeRepository { get; private init; }
}
