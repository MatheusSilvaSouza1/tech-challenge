using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class ContactMapping : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasMaxLength(40)
                .HasConversion(e => e.ToString(), value => Guid.Parse(value))
                .ValueGeneratedOnAdd()
                .HasValueGenerator((a, b) => new GuidValueGenerator());

            builder.Property(e => e.Email)
                .IsRequired();

            builder.Property(e => e.Name);

            builder.Property(e => e.Phone)
                .IsRequired();

            builder.HasOne(e => e.DDD)
                .WithMany(e => e.Contacts)
                .HasPrincipalKey(e => e.Id)
                .HasForeignKey(e => e.DDDId);
        }
    }
}