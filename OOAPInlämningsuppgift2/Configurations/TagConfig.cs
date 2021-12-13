using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOAPInlämningsuppgift2.Entities;

namespace OOAPInlämningsuppgift2.Configurations
{
    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
       
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(t => t.Id);              
        }
    }
}
