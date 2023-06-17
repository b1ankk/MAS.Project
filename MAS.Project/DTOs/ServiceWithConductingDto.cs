namespace MAS.Project.DTOs;

public class ServiceWithConductingDto : EntityDto
{
    public required decimal Price { get; set; }
    public required TimeSpan Duration { get; set; }
    public IList<MedicalWorkerDto> MedicalWorkersConducting { get; set; }
}
