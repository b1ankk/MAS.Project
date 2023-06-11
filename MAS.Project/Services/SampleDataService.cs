using MAS.Project.Model;
using MAS.Project.Model.ValueObjects;
using MAS.Project.Persistence;

namespace MAS.Project.Services;

public class SampleDataService
{
    private AppDbContext dbContext;
    
    public SampleDataService(AppDbContext dbContext) {
        this.dbContext = dbContext;
    }

    public void Seed() {
        var patient = new Patient {
            Registered = DateTime.Now,
            FirstName = "Stefan",
            MiddleNames = new List<string>() { "Andrzej", "Jakub" },
            LastName = "Takise",
            Birthdate = new DateOnly(2000, 1, 1),
            Email = Random.Shared.Next() + "stefan@email.com",
            PhoneNumber = "+48 432 234 543",
            PasswordHash = "###",
            Address = new Address() {
                Street = "Sreeeeeeeet",
                StreetNumber = "14A",
                ApartmentNumber = "13",
                City = "Warsaw",
                ZipCode = "00-123",
            },
        };

        var doctor = new Doctor() {
            FirstName = "Stefan",
            MiddleNames = new List<string>() { "Andrzej", "Jakub" },
            LastName = "Takise",
            Birthdate = new DateOnly(2000, 1, 1),
            Email = Random.Shared.Next() + "stefan@email.com" ,
            PhoneNumber = "+48 432 234 543",
            PasswordHash = "###",
            Address = new Address() {
                Street = "Sreeeeeeeet",
                StreetNumber = "14A",
                ApartmentNumber = "13",
                City = "Warsaw",
                ZipCode = "00-123",
            },
            Salary = 123,
            AcademicTitle = "AAAAAA",
            EmployedDate = DateOnly.FromDateTime(DateTime.Now)
        };

        dbContext.Patient.Add(patient);
        dbContext.Doctor.Add(doctor);
        dbContext.SaveChanges();
    }
}
