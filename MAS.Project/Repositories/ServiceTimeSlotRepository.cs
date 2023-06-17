using MAS.Project.Model;
using MAS.Project.Model.Enums;
using MAS.Project.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MAS.Project.Repositories;

public class ServiceTimeSlotRepository : RepositoryBase, IServiceTimeSlotRepository
{
    public ServiceTimeSlotRepository(AppDbContext dbContext)
        : base(dbContext) { }

    public async Task<IList<ServiceTimeSlot>> GetServiceTimeSlots(
        long serviceTypeId,
        long? medicalWorkerId,
        DateTime? dateFrom,
        DateTime? dateTo
    ) {
        return await DbContext.ServiceTimeSlot
            .Include(x => x.Service.ServiceType)
            .Include(x => x.Service.MedicalWorkersConducting
                .Where(mw => medicalWorkerId == null || mw.Id == medicalWorkerId))
            .Where(x => x.Service.ServiceType.Id == serviceTypeId)
            .Where(x => x.Service.MedicalWorkersConducting
                .Any(mw => medicalWorkerId == null || mw.Id == medicalWorkerId))
            .Where(x => x.Service.Active == true)
            .Where(x => dateFrom == null || x.Start >= dateFrom)
            .Where(x => dateTo == null || x.End <= dateTo)
            .Where(x => x.Status == ServiceTimeSlotStatus.Open)
            .OrderBy(x => x.Start)
            .ToListAsync();
    }
}
