using MAS.Project.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MAS.Project.Persistence.EntityConfigurations;

public static class UserDescendantConfigurationHelper
{
    public static void ConfigureAsUserDescendant<T>(this EntityTypeBuilder<T> builder)
        where T : class, IUser
    {
        builder.Ignore(x => x.FirstName);
        builder.Ignore(x => x.LastName);
        builder.Ignore(x => x.MiddleNames);
        builder.Ignore(x => x.Pesel);
        builder.Ignore(x => x.Birthdate);
        builder.Ignore(x => x.Email);
        builder.Ignore(x => x.PasswordHash);
        builder.Ignore(x => x.PhoneNumber);
        builder.Ignore(x => x.Address);
        
    }
}
