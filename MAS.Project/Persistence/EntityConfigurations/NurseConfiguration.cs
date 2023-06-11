using MAS.Project.Model;
using MAS.Project.Persistence.EntityConfigurationUtils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class NurseConfiguration : IEntityTypeConfiguration<Nurse>
{
    public void Configure(EntityTypeBuilder<Nurse> builder) {
        builder.Property(x => x.Certificates)
            .HasConversion<SetJsonConverter<string>, SetValueComparer<string>>();
    }
}
