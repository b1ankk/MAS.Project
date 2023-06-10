using MAS.Project.Model.ValueObjects;

namespace MAS.Project.Model;

public class Patient : IUser
{
    public Patient() {
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


    public required DateTime Registered { get; set; }

    public User Parent { get; }

    public required string FirstName {
        get => Parent.FirstName;
        set => Parent.FirstName = value;
    }

    public required IList<string> MiddleNames {
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


    public static implicit operator User(Patient patient) {
        return patient.Parent;
    }
}
