using MAS.Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class ServiceResultConfiguration : IEntityTypeConfiguration<ServiceResult>
{
    public void Configure(EntityTypeBuilder<ServiceResult> builder) {
        builder.HasOne(x => x.ServiceTimeSlot)
            .WithOne(x => x.ServiceResult)
            .HasPrincipalKey<ServiceTimeSlot>()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PatientIssuedFor)
            .WithMany(x => x.ServiceResults)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
