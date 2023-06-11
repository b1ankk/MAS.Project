namespace MAS.Project.Model;

public class ServiceType
{
    public required string Name { get; set; }
    public TimeSpan? MinDuration { get; set; }
    public TimeSpan? MaxDuration { get; set; }
    public TimeOnly? MinStartTime { get; set; }
    public TimeOnly? MaxStartTime { get; set; }
    public string? RecommendationsBeforeService { get; set; }

    public ICollection<Service> Services { get; set; } = null!;
    public ICollection<MedicalWorker> AuthorizedMedicalWorkers { get; set; } = null!;
    public ICollection<ServiceReferral> ServiceReferrals { get; set; } = null!;
}
