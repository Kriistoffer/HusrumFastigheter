using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOAPInlämningsuppgift2.Entities;

namespace OOAPInlämningsuppgift2.Configurations
{
    public class LogConfig : IEntityTypeConfiguration<Logs>
    {
        public void Configure(EntityTypeBuilder<Logs> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();
            builder.Property(d => d.DateTime)
                .IsRequired();
            builder.Property(e => e.Event)
                .IsRequired();
            builder.Property(t => t.Tenant)
                .IsRequired();
            builder.Property(d => d.Door)
                .IsRequired();
        }
    }
}
