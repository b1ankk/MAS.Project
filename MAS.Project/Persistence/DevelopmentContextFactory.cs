using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MAS.Project.Persistence;

public class DevelopmentContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=MAS;User ID=sa;Password=Password1;Trust Server Certificate=true");

        return new AppDbContext(optionsBuilder.Options);
    }
}
