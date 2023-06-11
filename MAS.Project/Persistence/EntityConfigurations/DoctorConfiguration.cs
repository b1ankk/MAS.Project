using MAS.Project.Model;
using MAS.Project.Persistence.EntityConfigurationUtils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder) {
        builder.Property(x => x.Specializations)
            .HasConversion<SetJsonConverter<string>, SetValueComparer<string>>();
    }
}
