namespace MAS.Project.Model;

public class Service : Entity
{
    public required decimal Price { get; set; }
    public ISet<string> CronForTimeSlotGeneration { get; set; } = new HashSet<string>();
    public required bool Active { get; set; }
    public required TimeSpan Duration { get; set; }

    public ICollection<ServiceTimeSlot> ServiceTimeSlots { get; set; } = null!;
    public ICollection<MedicalWorker> MedicalWorkersConducting { get; set; } = null!;
    public required ServiceType ServiceType { get; set; }
}
