using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOAPInlämningsuppgift2.Entities;

namespace OOAPInlämningsuppgift2.Configurations
{
    public class LogConfig : IEntityTypeConfiguration<Logs>
    {
        public void Configure(EntityTypeBuilder<Logs> builder)
        {
            builder.Property(l => l.Id)
                .IsRequired();
        }
    }
}
