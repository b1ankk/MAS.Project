using MAS.Project.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public class ServiceReferralConfiguration : IEntityTypeConfiguration<ServiceReferral>
{
    public void Configure(EntityTypeBuilder<ServiceReferral> builder) {
        builder.HasOne(x => x.ServiceResult)
            .WithMany(x => x.ServiceReferrals)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.ServiceTimeSlotBooked)
            .WithOne(x => x.ServiceReferralBookedWith)
            .HasPrincipalKey<ServiceTimeSlot>()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ServiceType)
            .WithMany(x => x.ServiceReferrals)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.DoctorIssuedBy)
            .WithMany(x => x.ServiceReferralsIssued)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
