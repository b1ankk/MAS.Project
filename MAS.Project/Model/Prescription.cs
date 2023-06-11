namespace MAS.Project.Model;

public class Prescription
{
    public required string PatientFirstName { get; init; }
    public required string PatientLastName { get; init; }
    public string? PatientPesel { get; init; }
    public required string IssuerFirstName { get; init; }
    public required string IssuerLastName { get; init; }
    public required DateTime Issued { get; init; }
    public required DateOnly ExpiresDate { get; init; }
}
