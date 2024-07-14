using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>

    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseNpgsql("Host=localhost; Database=tech-challenge; Username=tech-challenge; Password=tech-challenge");

            return new Context(optionsBuilder.Options);
        }
    }
}