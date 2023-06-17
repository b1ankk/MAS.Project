using MAS.Project.Model;

namespace MAS.Project.Repositories;

public interface IServiceTimeSlotRepository
{
    Task<IList<ServiceTimeSlot>> GetServiceTimeSlots(
        long serviceTypeId,
        long? medicalWorkerId,
        DateTime? dateFrom,
        DateTime? dateTo
    );
}
