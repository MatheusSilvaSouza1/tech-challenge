using Domain;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }

        public virtual DbSet<Contact> Contacts => Set<Contact>();
        public virtual DbSet<DDD> DDDs => Set<DDD>();        
    }
}