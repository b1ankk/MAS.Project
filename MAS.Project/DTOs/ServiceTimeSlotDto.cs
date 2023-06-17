namespace MAS.Project.DTOs;

public class ServiceTimeSlotDto : EntityDto
{
    public required DateTime Start { get; set; }
    public required DateTime End { get; set; }

    public required ServiceWithConductingDto Service { get; set; }
}
