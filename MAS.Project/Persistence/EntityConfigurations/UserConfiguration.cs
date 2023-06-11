using MAS.Project.Model;
using MAS.Project.Persistence.EntityConfigurationUtils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder) {
        builder.Property(x => x.FirstName)
            .HasMaxLength(50);
        builder.Property(x => x.LastName)
            .HasMaxLength(50);
        builder.Property(p => p.MiddleNames)
            .HasConversion<ListJsonConverter<string>, ListValueComparer<string>>();
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
