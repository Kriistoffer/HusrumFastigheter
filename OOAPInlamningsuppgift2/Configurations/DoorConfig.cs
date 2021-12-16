using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOAPInlamningsuppgift2.Entities;

namespace OOAPInlamningsuppgift2.Configurations
{
    public class DoorConfig : IEntityTypeConfiguration<Door>
    {
        public void Configure(EntityTypeBuilder<Door> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
