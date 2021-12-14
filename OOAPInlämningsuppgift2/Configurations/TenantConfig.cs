using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOAPInlämningsuppgift2.Entities;

namespace OOAPInlämningsuppgift2.Configurations
{
    public class TenantConfig : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(t => t.ApartmentNumber)
                .IsRequired();

            builder
                .Property(t => t.FirstName)
                .IsRequired();

            builder
                .Property(t => t.LastName)
                .IsRequired();

            builder
                .Property(t => t.TagId);
        }
    }
}
