using MAS.Project.Model.ValueObjects;

namespace MAS.Project.Model;

public abstract class MedicalWorker : Entity, IUser
{
    protected MedicalWorker() {
        Parent = new User(this) {
            FirstName = null!,
            LastName = null!,
            Birthdate = default,
            Email = null!,
            PhoneNumber = null!,
            PasswordHash = null!,
            Address = default
        };
    }


    public required decimal Salary { get; set; }
    public required DateOnly EmployedDate { get; set; }

    public User Parent { get; }

    public override long Id {
        get => Parent.Id;
        set => Parent.Id = value;
    }

    public required string FirstName {
        get => Parent.FirstName;
        set => Parent.FirstName = value;
    }

    public IList<string> MiddleNames {
        get => Parent.MiddleNames;
        set => Parent.MiddleNames = value;
    }

    public required string LastName {
        get => Parent.LastName;
        set => Parent.LastName = value;
    }

    public string? Pesel {
        get => Parent.Pesel;
        set => Parent.Pesel = value;
    }

    public required DateOnly Birthdate {
        get => Parent.Birthdate;
        set => Parent.Birthdate = value;
    }

    public required string Email {
        get => Parent.Email;
        set => Parent.Email = value;
    }

    public required string PhoneNumber {
        get => Parent.PhoneNumber;
        set => Parent.PhoneNumber = value;
    }

    public required string PasswordHash {
        get => Parent.PasswordHash;
        set => Parent.PasswordHash = value;
    }

    public required Address Address {
        get => Parent.Address;
        set => Parent.Address = value;
    }

    public bool IsPatient => Parent.IsPatient;

    public bool IsMedicalWorker => Parent.IsMedicalWorker;

    public static implicit operator User(MedicalWorker medicalWorker) {
        return medicalWorker.Parent;
    }
}
