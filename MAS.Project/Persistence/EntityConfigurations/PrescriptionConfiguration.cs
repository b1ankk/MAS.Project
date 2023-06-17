using MAS.Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder) {
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

        builder.HasOne(x => x.ServiceResult)
            .WithMany(x => x.Prescriptions)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.DoctorIssuedBy)
            .WithMany(x => x.PrescriptionsIssued)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
