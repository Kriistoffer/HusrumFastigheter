using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOAPInlämningsuppgift2.Entities;

namespace OOAPInlämningsuppgift2.Configurations
{
    public class DoorConfig : IEntityTypeConfiguration<Door>
    {
        public void Configure(EntityTypeBuilder<Door> builder)
        {
            builder
                .HasKey(d => d.Designation);
            builder
                .Property(d => d.Tags)
                .IsRequired();
             
        }
    }
}
