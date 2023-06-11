using MAS.Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder) {
        builder.HasOne(x => x.ServiceResult)
            .WithMany(x => x.Prescriptions)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.DoctorIssuedBy)
            .WithMany(x => x.PrescriptionsIssued)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
