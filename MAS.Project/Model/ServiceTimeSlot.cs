using MAS.Project.Model.Enums;

namespace MAS.Project.Model;

public class ServiceTimeSlot : Entity
{
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }
    public required ServiceTimeSlotStatus Status { get; set; }
    public required bool Archived { get; set; }
    public string? PatientsNote { get; set; }

    public required Service Service { get; set; }
    public ServiceResult? ServiceResult { get; set; }
    public Patient? PatientBookedBy { get; set; }
    public ServiceReferral? ServiceReferralBookedWith { get; set; }
}
