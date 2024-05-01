using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class DDDMapping : IEntityTypeConfiguration<DDD>
    {
        public void Configure(EntityTypeBuilder<DDD> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id);

            builder.Property(e => e.Region)
                .IsRequired();

        }
    }
}