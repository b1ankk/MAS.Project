namespace MAS.Project.DTOs;

public class ServiceTypeDto
{
    public required string Name { get; set; }
    public TimeSpan? MinDuration { get; set; }
    public TimeSpan? MaxDuration { get; set; }
    public TimeOnly? MinStartTime { get; set; }
    public TimeOnly? MaxStartTime { get; set; }
    public string? RecommendationsBeforeService { get; set; }
}
