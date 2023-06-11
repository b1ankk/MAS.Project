using MAS.Project.Model;
using MAS.Project.Persistence.EntityConfigurationUtils;
using Microsoft.EntityFrameworkCore;

namespace MAS.Project.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options) { }
    
    public DbSet<Doctor> Doctor { get; protected set; } = null!;
    public DbSet<MedicalWorker> MedicalWorker { get; protected set; } = null!;
    public DbSet<Medication> Medication { get; protected set; } = null!;
    public DbSet<MedicationOnPrescription> MedicationOnPrescription { get; protected set; } = null!;
    public DbSet<Nurse> Nurse { get; protected set; } = null!;
    public DbSet<Patient> Patient { get; protected set; } = null!;
    public DbSet<Prescription> Prescription { get; protected set; } = null!;
    public DbSet<Service> Service { get; protected set; } = null!;
    public DbSet<ServiceReferral> ServiceReferral { get; protected set; } = null!;
    public DbSet<ServiceResult> ServiceResult { get; protected set; } = null!;
    public DbSet<ServiceTimeSlot> ServiceTimeSlot { get; protected set; } = null!;
    public DbSet<ServiceType> ServiceType { get; protected set; } = null!;
    public DbSet<SickLeave> SickLeave { get; protected set; } = null!;
    public DbSet<User> User { get; protected set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");

        configurationBuilder.Properties<TimeOnly>()
            .HaveConversion<TimeOnlyConverter>();
    }
}
