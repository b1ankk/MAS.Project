using MAS.Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class MedicationOnPrescriptionConfiguration : IEntityTypeConfiguration<MedicationOnPrescription>
{
    public void Configure(EntityTypeBuilder<MedicationOnPrescription> builder) {
        builder.Property(x => x.FractionRefunded)
            .HasPrecision(8, 5);
            
        builder.HasOne(x => x.Medication)
            .WithMany(x => x.MedicationOnPrescriptions)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Prescription)
            .WithMany(x => x.MedicationsOnPrescription)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
