using MAS.Project.Model;
using MAS.Project.Model.Enums;
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
        if (dbContext.User.Any()) {
            Console.WriteLine("User is not empty, skipping seed process");
            return;
        }

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

        var doctor1 = new Doctor() {
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
        var doctor2 = new Doctor() {
            FirstName = "Stefan2",
            MiddleNames = new List<string>() { "Andrzej", "Jakub" },
            LastName = "Takise2",
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

        var bloodTest = new ServiceType() {
            Name = "Blood test",
            MinDuration = TimeSpan.FromMinutes(5),
            MaxDuration = TimeSpan.FromMinutes(15),
            MinStartTime = new TimeOnly(6, 0),
            MaxStartTime = new TimeOnly(12, 30),
            AuthorizedMedicalWorkers = new List<MedicalWorker>() { nurse }
        };
        var consultation = new ServiceType() {
            Name = "General practitioner consultation",
            AuthorizedMedicalWorkers = new List<MedicalWorker>() { doctor1, doctor2 },
        };

        var bloodTestServiceNurse = new Service() {
            Active = true,
            Duration = TimeSpan.FromMinutes(10),
            Price = 50,
            ServiceType = bloodTest,
            MedicalWorkersConducting = new List<MedicalWorker>() { nurse }
        };
        var consultationServiceDoctor1 = new Service() {
            Active = true,
            Duration = TimeSpan.FromMinutes(20),
            Price = 100,
            ServiceType = consultation,
            MedicalWorkersConducting = new List<MedicalWorker>() { doctor1 }
        };
        var consultationServiceDoctor2 = new Service() {
            Active = true,
            Duration = TimeSpan.FromMinutes(30),
            Price = 150,
            ServiceType = consultation,
            MedicalWorkersConducting = new List<MedicalWorker>() { doctor2 }
        };


        var bloodTestTimeSlots = MakeDateTimeSequence(new DateTime(2023, 7, 1, 6, 0, 0), TimeSpan.FromMinutes(10), 20)
            .Select(
                dateTime => new ServiceTimeSlot() {
                    Service = bloodTestServiceNurse,
                    Start = dateTime,
                    End = dateTime.AddMinutes(10),
                    Archived = false,
                    Status = ServiceTimeSlotStatus.Open,
                }
            )
            .ToList();
        var consultationDoctor1TimeSlots = MakeDateTimeSequence(new DateTime(2023, 7, 1, 8, 0, 0), TimeSpan.FromMinutes(20), 20)
            .Select(
                dateTime => new ServiceTimeSlot() {
                    Service = consultationServiceDoctor1,
                    Start = dateTime,
                    End = dateTime.AddMinutes(20),
                    Archived = false,
                    Status = ServiceTimeSlotStatus.Open,
                }
            )
            .ToList();
        var consultationDoctor2TimeSlots = MakeDateTimeSequence(new DateTime(2023, 7, 1, 9, 0, 0), TimeSpan.FromMinutes(30), 20)
            .Select(
                dateTime => new ServiceTimeSlot() {
                    Service = consultationServiceDoctor2,
                    Start = dateTime,
                    End = dateTime.AddMinutes(30),
                    Archived = false,
                    Status = ServiceTimeSlotStatus.Open,
                }
            )
            .ToList();

        dbContext.Patient.Add(patient);
        dbContext.Doctor.AddRange(doctor1);
        dbContext.Nurse.AddRange(nurse);
        dbContext.ServiceType.AddRange(bloodTest, consultation);
        dbContext.Service.AddRange(bloodTestServiceNurse, consultationServiceDoctor1, consultationServiceDoctor2);
        dbContext.ServiceTimeSlot.AddRange(bloodTestTimeSlots);
        dbContext.ServiceTimeSlot.AddRange(consultationDoctor1TimeSlots);
        dbContext.ServiceTimeSlot.AddRange(consultationDoctor2TimeSlots);
        dbContext.SaveChanges();
    }

    private static IEnumerable<DateTime> MakeDateTimeSequence(DateTime start, TimeSpan difference, int count) {
        for (int i = 0; i < count; ++i) {
            yield return start.Add(difference * i);
        }
    }

}
