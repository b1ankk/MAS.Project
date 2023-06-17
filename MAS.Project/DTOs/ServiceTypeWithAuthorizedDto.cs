﻿namespace MAS.Project.DTOs;

public class ServiceTypeWithAuthorizedDto : EntityDto
{
    public required string Name { get; set; }
    public TimeSpan? MinDuration { get; set; }
    public TimeSpan? MaxDuration { get; set; }
    public TimeOnly? MinStartTime { get; set; }
    public TimeOnly? MaxStartTime { get; set; }
    public string? RecommendationsBeforeService { get; set; }

    public IList<MedicalWorker> AuthorizedMedicalWorkers { get; set; }
    
    public class MedicalWorker : EntityDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
