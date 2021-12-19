using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOAPInlamningsuppgift2.Entities;

namespace OOAPInlamningsuppgift2.Configurations
{
    //Entity framework configuration for event 
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Code);
        }
    }
}
