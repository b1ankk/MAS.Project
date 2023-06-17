using MAS.Project.Model.ValueObjects;

namespace MAS.Project.Model;

public class Patient : Entity, IUser
{
    public Patient() {
        ParentUser = new User(this) {
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

    public ICollection<ServiceResult> ServiceResults { get; set; }
    public ICollection<ServiceTimeSlot> BookedServiceTimeSlots { get; set; }
    
    public User ParentUser { get; }

    public override long Id {
        get => ParentUser.Id;
        set => ParentUser.Id = value;
    }

    public required string FirstName {
        get => ParentUser.FirstName;
        set => ParentUser.FirstName = value;
    }

    public required IList<string> MiddleNames {
        get => ParentUser.MiddleNames;
        set => ParentUser.MiddleNames = value;
    }

    public required string LastName {
        get => ParentUser.LastName;
        set => ParentUser.LastName = value;
    }

    public string? Pesel {
        get => ParentUser.Pesel;
        set => ParentUser.Pesel = value;
    }

    public required DateOnly Birthdate {
        get => ParentUser.Birthdate;
        set => ParentUser.Birthdate = value;
    }

    public required string Email {
        get => ParentUser.Email;
        set => ParentUser.Email = value;
    }

    public required string PhoneNumber {
        get => ParentUser.PhoneNumber;
        set => ParentUser.PhoneNumber = value;
    }

    public required string PasswordHash {
        get => ParentUser.PasswordHash;
        set => ParentUser.PasswordHash = value;
    }

    public required Address Address {
        get => ParentUser.Address;
        set => ParentUser.Address = value;
    }

    public bool IsPatient => ParentUser.IsPatient;

    public bool IsMedicalWorker => ParentUser.IsMedicalWorker;


    public static implicit operator User(Patient patient) {
        return patient.ParentUser;
    }
}
