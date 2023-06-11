namespace MAS.Project.Model;

public class Nurse : MedicalWorker
{
    public ISet<string> Certificates { get; set; } = new HashSet<string>();
}
