namespace MAS.Project.Model;

public class MedicationOnPrescription : Entity
{
    public required int Amount { get; set; }
    public required decimal FractionRefunded { get; set; }

    public required Prescription Prescription { get; set; }
    public required Medication Medication { get; set; }
}
