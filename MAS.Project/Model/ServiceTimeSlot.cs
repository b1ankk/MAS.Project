using MAS.Project.Model.Enums;

namespace MAS.Project.Model;

public class ServiceTimeSlot
{
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }
    public required ServiceTimeSlotStatus Status { get; set; }
    public required bool Archived { get; set; }
    public string? PatientsNote { get; set; }

    public Service Service { get; set; } = null!;
    public ServiceResult? ServiceResult { get; set; }
    public Patient? BookedBy { get; set; }
    public ServiceReferral? BookedWithServiceReferral { get; set; }
}
