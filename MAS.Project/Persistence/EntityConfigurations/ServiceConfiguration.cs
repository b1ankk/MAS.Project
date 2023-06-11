using MAS.Project.Model;
using MAS.Project.Persistence.EntityConfigurationUtils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder) {
        builder.Property(x => x.Price)
            .HasPrecision(6, 2);
        builder.Property(x => x.CronForTimeSlotGeneration)
            .HasConversion<SetJsonConverter<string>, SetValueComparer<string>>();

        builder.HasOne(x => x.ServiceType)
            .WithMany(x => x.Services)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.MedicalWorkersConducting)
            .WithMany(x => x.ConductedServices);
    }
}
