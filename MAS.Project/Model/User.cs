using MAS.Project.Model.ValueObjects;

namespace MAS.Project.Model;

public class User : IUser
{
    private readonly Patient? patient;
    private readonly MedicalWorker? medicalWorker;

    public User(Patient patient) {
        if (patient is null)
            throw new ArgumentNullException(nameof(patient));
        if (patient.Parent is not null && !ReferenceEquals(patient.Parent, this))
            throw new InvalidOperationException(
                $"{nameof(User)} parent has already been assigned for this {nameof(Patient)}"
            );
        this.patient = patient;
    }

    public User(MedicalWorker medicalWorker) {
        if (medicalWorker is null)
            throw new ArgumentNullException(nameof(medicalWorker));
        if (medicalWorker.Parent is not null && !ReferenceEquals(medicalWorker.Parent, this))
            throw new InvalidOperationException(
                $"{nameof(User)} parent has already been assigned for this {nameof(MedicalWorker)}"
            );
        this.medicalWorker = medicalWorker;
    }

    public required string FirstName { get; set; }
    public IList<string> MiddleNames { get; set; } = new List<string>();
    public required string LastName { get; set; }
    public string? Pesel { get; set; }
    public required DateOnly Birthdate { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string PasswordHash { get; set; }
    public required Address Address { get; set; }

    public bool IsPatient => patient is not null;
    public bool IsMedicalWorker => medicalWorker is not null;


    public static explicit operator Patient(User user) {
        return user.patient
            ?? throw new InvalidCastException(
                $"Unable to cast object of type {nameof(User)} to type {nameof(Patient)}"
            );
    }

    public static explicit operator MedicalWorker(User user) {
        return user.medicalWorker
            ?? throw new InvalidCastException(
                $"Unable to cast object of type {nameof(User)} to type {nameof(MedicalWorker)}"
            );
    }
}
