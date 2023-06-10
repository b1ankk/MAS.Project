using MAS.Project.Model.ValueObjects;

namespace MAS.Project.Model;

public interface IUser
{
    string FirstName { get; set; }
    IList<string> MiddleNames { get; set; }
    string LastName { get; set; }
    string? Pesel { get; set; }
    DateOnly Birthdate { get; set; }
    string Email { get; set; }
    string PhoneNumber { get; set; }
    string PasswordHash { get; set; }
    bool IsPatient { get; }
    bool IsMedicalWorker { get; }
    Address Address { get; set; }
}
