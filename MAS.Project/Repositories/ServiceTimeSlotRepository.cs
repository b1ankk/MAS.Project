using MAS.Project.Model;
using MAS.Project.Model.Enums;
using MAS.Project.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MAS.Project.Repositories;

public class ServiceTimeSlotRepository : RepositoryBase, IServiceTimeSlotRepository
{
    public ServiceTimeSlotRepository(AppDbContext dbContext)
        : base(dbContext) { }

    public async Task<IList<ServiceTimeSlot>> GetServiceTimeSlotsAsync(
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

    public async Task BookServiceTimeSlotAsync(long serviceTimeSlotId, long patientId) {
        var serviceTimeSlot = await DbContext.ServiceTimeSlot.FindAsync(serviceTimeSlotId);
        var patient = await DbContext.Patient.FindAsync(patientId);

        if (serviceTimeSlot?.Status != ServiceTimeSlotStatus.Open
            || serviceTimeSlot.PatientBookedBy is not null
            || serviceTimeSlot.Archived) {
            throw new InvalidOperationException();
        }

        serviceTimeSlot.PatientBookedBy = patient;
        serviceTimeSlot.Status = ServiceTimeSlotStatus.Booked;

        await SaveChangesASync();
    }

    public async Task<IList<ServiceTimeSlot>> GetUpcomingServices(long patientId) {
        return await DbContext.ServiceTimeSlot
            .Include(x => x.Service.ServiceType)
            .Include(x => x.Service.MedicalWorkersConducting)
            .Where(x => x.Status == ServiceTimeSlotStatus.Booked)
            .Where(x => x.PatientBookedBy!.Id == patientId)
            .OrderBy(x => x.Start)
            .ToListAsync();
    }
}
