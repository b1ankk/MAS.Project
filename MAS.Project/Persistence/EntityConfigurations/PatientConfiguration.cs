using MAS.Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder) {
        builder.ConfigureAsUserDescendant();

        builder.HasOne(x => x.ParentUser)
            .WithOne()
            .HasPrincipalKey<User>(x => x.Id)
            .HasForeignKey<Patient>(x => x.Id)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Navigation(x => x.ParentUser)
            .AutoInclude();
    }
}
