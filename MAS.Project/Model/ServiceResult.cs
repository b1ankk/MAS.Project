﻿namespace MAS.Project.Model;

public class ServiceResult
{
    public string? Recommendations { get; set; }
    public string? ExaminationResults { get; set; }
    public required DateTime Created { get; set; }

    public required ServiceTimeSlot ServiceTimeSlot { get; set; }
    public required Patient PatientIssuedFor { get; set; }
    public ICollection<ServiceReferral> ServiceReferrals { get; set; } = null!;
    public SickLeave? SickLeave { get; set; }
    public Prescription? Prescription { get; set; }
}
