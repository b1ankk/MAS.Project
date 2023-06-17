namespace MAS.Project.Repositories;

public interface IUnitOfWork
{
    IServiceTypeRepository ServiceTypeRepository { get; }
    IServiceTimeSlotRepository ServiceTimeSlotRepository { get; }
}
