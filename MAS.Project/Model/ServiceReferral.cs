namespace MAS.Project.Model;

public class ServiceReferral
{
    public required DateTime Issued { get; set; }
    public required DateOnly Expires { get; set; }
}
