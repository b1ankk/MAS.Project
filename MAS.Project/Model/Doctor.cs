namespace MAS.Project.Model;

public class Doctor : MedicalWorker
{
    public required string AcademicTitle { get; set; }
    public ISet<string> Specializations { get; set; } = new HashSet<string>();

    public ICollection<ServiceReferral> ServiceReferralsIssued { get; set; } = null!;
    public ICollection<SickLeave> SickLeavesIssued { get; set; } = null!;
    public ICollection<Prescription> PrescriptionsIssued { get; set; } = null!;
}
