using System.Text.Json;
using MAS.Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder) {
        builder.Property(x => x.FirstName)
            .HasMaxLength(50);
        builder.Property(x => x.LastName)
            .HasMaxLength(50);
        builder.Property(p => p.MiddleNames)
            .HasConversion<string>(
                v => JsonSerializer.Serialize(v, JsonSerializerOptions.Default),
                v => JsonSerializer.Deserialize<List<string>>(v, JsonSerializerOptions.Default)!,
                new ValueComparer<IList<string>>(
                    (c1, c2) => c1!.SequenceEqual(c2!),
                    c => c.Aggregate(0, (l, r) => HashCode.Combine(l, r.GetHashCode())),
                    c => c.ToList())
            );
        builder.Property(x => x.Pesel)
            .HasMaxLength(11);
        builder.Property(x => x.Email)
            .HasMaxLength(320);
        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(15);

        builder.OwnsOne(
            x => x.Address,
            addressBuilder => {
                addressBuilder.Property(x => x.Street)
                    .HasMaxLength(100);
                addressBuilder.Property(x => x.StreetNumber)
                    .HasMaxLength(10);
                addressBuilder.Property(x => x.ApartmentNumber)
                    .HasMaxLength(10);
                addressBuilder.Property(x => x.City)
                    .HasMaxLength(50);
                addressBuilder.Property(x => x.ZipCode)
                    .HasMaxLength(6);
            }
        );

        builder.HasIndex(x => x.Email)
            .IsUnique();
    }
}
