using MAS.Project.Persistence;

namespace MAS.Project.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(
        AppDbContext dbContext,
        IServiceTypeRepository serviceTypeRepository,
        IServiceTimeSlotRepository serviceTimeSlotRepository
    ) {
        this.dbContext = dbContext;
        ServiceTypeRepository = serviceTypeRepository;
        ServiceTimeSlotRepository = serviceTimeSlotRepository;
    }

    private readonly AppDbContext dbContext;
    
    public IServiceTypeRepository ServiceTypeRepository { get; private init; }
    public IServiceTimeSlotRepository ServiceTimeSlotRepository { get; private init; }

    public async Task SaveChangesAsync() {
        await dbContext.SaveChangesAsync();
    }
}
