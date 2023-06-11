using MAS.Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class ServiceTimeSlotConfiguration : IEntityTypeConfiguration<ServiceTimeSlot>
{
    public void Configure(EntityTypeBuilder<ServiceTimeSlot> builder) {
        builder.HasOne(x => x.Service)
            .WithMany(x => x.ServiceTimeSlots)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.PatientBookedBy)
            .WithMany(x => x.BookedServiceTimeSlots)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
