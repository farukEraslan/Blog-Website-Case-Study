using BlogWebsite.Core.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogWebsite.DataAccess.Config
{
    public class TagEntityConfiguration : IEntityTypeConfiguration<TagEntity>
    {
        public void Configure(EntityTypeBuilder<TagEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TagName).HasMaxLength(128);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.ModifiedDate);
        }
    }
}
