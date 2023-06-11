using MAS.Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class MedicalWorkerConfiguration : IEntityTypeConfiguration<MedicalWorker>
{
    public void Configure(EntityTypeBuilder<MedicalWorker> builder) {
        builder.ConfigureAsUserDescendant();
        
        builder.HasOne(x => x.Parent)
            .WithOne()
            .HasPrincipalKey<User>(x => x.Id)
            .HasForeignKey<MedicalWorker>(x => x.Id)
            .IsRequired();

        builder.UseTptMappingStrategy();
    }
}
