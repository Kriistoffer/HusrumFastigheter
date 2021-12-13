using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOAPInlämningsuppgift2.Entities;

namespace OOAPInlämningsuppgift2.Configurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder
                .HasKey

            builder
                .Property(t => t.ApartmentNumber);

            builder
                .Property(t => t.FirstName);

            builder
                .Property(t => t.LastName);

            builder
                .Property(t => t.Tag);
        }
    }
}
