using MAS.Project.Model;

namespace MAS.Project.Repositories;

public interface IServiceTimeSlotRepository
{
    Task<IList<ServiceTimeSlot>> GetServiceTimeSlotsAsync(
        long serviceTypeId,
        long? medicalWorkerId,
        DateTime? dateFrom,
        DateTime? dateTo
    );

    Task BookServiceTimeSlotAsync(long serviceTimeSlotId, long patientId);
}
