using MAS.Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class SickLeaveConfiguration : IEntityTypeConfiguration<SickLeave>
{
    public void Configure(EntityTypeBuilder<SickLeave> builder) {
        builder.Property(x => x.PatientFirstName)
            .HasMaxLength(50);
        builder.Property(x => x.PatientLastName)
            .HasMaxLength(50);     
        builder.Property(x => x.IssuerFirstName)
            .HasMaxLength(50);
        builder.Property(x => x.IssuerLastName)
            .HasMaxLength(50);
        builder.Property(x => x.PatientPesel)
            .HasMaxLength(11);
        builder.Property(x => x.CompanyName)
            .HasMaxLength(80);
        builder.Property(x => x.CompanyNip)
            .HasMaxLength(9);

        builder.HasOne(x => x.ServiceResult)
            .WithOne(x => x.SickLeave)
            .HasPrincipalKey<ServiceResult>()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.DoctorIssuedBy)
            .WithMany(x => x.SickLeavesIssued)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
