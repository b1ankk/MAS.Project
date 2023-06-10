namespace MAS.Project.Model;

public class Doctor : MedicalWorker
{
    public required string AcademicTitle { get; set; }
    public ISet<string> Specializations { get; set; } = new HashSet<string>();
}
