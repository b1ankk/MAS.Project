namespace MAS.Project.Model;

public class ServiceReferral : Entity
{
    public required DateTime Issued { get; set; }
    public required DateOnly Expires { get; set; }

    public required ServiceType ServiceType { get; set; }
    public required Doctor DoctorIssuedBy { get; set; }
    public required ServiceResult ServiceResult { get; set; }
    public ServiceTimeSlot? ServiceTimeSlotBooked { get; set; }
}
