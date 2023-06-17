namespace MAS.Project.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(
        IServiceTypeRepository serviceTypeRepository,
        IServiceTimeSlotRepository serviceTimeSlotRepository
    ) {
        ServiceTypeRepository = serviceTypeRepository;
        ServiceTimeSlotRepository = serviceTimeSlotRepository;
    }

    public IServiceTypeRepository ServiceTypeRepository { get; private init; }
    public IServiceTimeSlotRepository ServiceTimeSlotRepository { get; private init; }
}
