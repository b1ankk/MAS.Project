namespace MAS.Project.Model;

public class Nurse
{
    public ISet<string> Certificates { get; set; } = new HashSet<string>();
}
