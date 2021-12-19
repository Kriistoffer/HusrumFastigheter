using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOAPInlamningsuppgift2.Entities;

namespace OOAPInlamningsuppgift2.Configurations
{
    public class LogConfig : IEntityTypeConfiguration<Logs>
    {
        public void Configure(EntityTypeBuilder<Logs> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(d => d.DateTime)
                .IsRequired();

            builder.Property(f => f.FirstName)
                .IsRequired();

            builder.Property(l => l.LastName)
                .IsRequired();

            builder.Property(c => c.Code)
                .IsRequired();

            builder.Property(d => d.Description)
                .IsRequired();

            builder.Property(t => t.TagId)
                .IsRequired();

            builder.Property(d => d.Designation)
                .IsRequired();
        }
    }
}
