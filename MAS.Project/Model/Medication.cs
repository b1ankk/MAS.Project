namespace MAS.Project.Model;

public class Medication : Entity
{
    public required string Name { get; set; }
    public required decimal StandardPrice { get; set; }

    public ICollection<MedicationOnPrescription> MedicationOnPrescriptions { get; set; } = null!;
}
