namespace MAS.Project.Model;

public class ServiceResult
{
    public string? Reccomendations { get; set; }
    public string? ExaminationResults { get; set; }
    public required DateTime Created { get; set; }
}
