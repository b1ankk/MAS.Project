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
        if (dbContext.User.Any())
            return;

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
            Salary = 123,
            AcademicTitle = "lek. med.",
            EmployedDate = DateOnly.FromDateTime(DateTime.Now)
        };
        
        var nurse = new Nurse() {
            FirstName = "Stefania",
            MiddleNames = new List<string>() { "Anna" },
            LastName = "Takatam",
            Birthdate = new DateOnly(1990, 1, 1),
            Email = Random.Shared.Next() + "stefania@email.com",
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
            EmployedDate = DateOnly.FromDateTime(DateTime.Now),
            Certificates = new HashSet<string>() { "Blood testing or smth idk" }
        };

        var serviceType1 = new ServiceType() {
            Name = "Blood test",
            MinDuration = TimeSpan.FromMinutes(5),
            MaxDuration = TimeSpan.FromMinutes(15),
            MinStartTime = new TimeOnly(6, 0),
            MaxStartTime = new TimeOnly(12, 30),
            AuthorizedMedicalWorkers = new List<MedicalWorker>() { nurse }
        };
        var serviceType2 = new ServiceType() {
            Name = "General practitioner consultation",
            AuthorizedMedicalWorkers = new List<MedicalWorker>() { doctor },
        };

        var service1 = new Service() {
            Active = true,
            Duration = TimeSpan.FromMinutes(10),
            Price = 50,
            ServiceType = serviceType1,
            MedicalWorkersConducting = new List<MedicalWorker>() { nurse }
        };
        var service2 = new Service() {
            Active = true,
            Duration = TimeSpan.FromMinutes(20),
            Price = 50,
            ServiceType = serviceType2,
            MedicalWorkersConducting = new List<MedicalWorker>() { doctor }
        };

        dbContext.Patient.Add(patient);
        dbContext.Doctor.AddRange(doctor);
        dbContext.Nurse.AddRange(nurse);
        dbContext.ServiceType.AddRange(serviceType1, serviceType2);
        dbContext.Service.AddRange(service1, service2);
        dbContext.SaveChanges();
    }
}
