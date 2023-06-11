using MAS.Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class SickLeaveConfiguration : IEntityTypeConfiguration<SickLeave>
{
    public void Configure(EntityTypeBuilder<SickLeave> builder) {
        builder.HasOne(x => x.ServiceResult)
            .WithOne(x => x.SickLeave)
            .HasPrincipalKey<ServiceResult>()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.DoctorIssuedBy)
            .WithMany(x => x.SickLeavesIssued)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
