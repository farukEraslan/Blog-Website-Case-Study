using BlogWebsite.Core.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebsite.DataAccess.Config
{
    public class BlogPostTagEntityConfiguration : IEntityTypeConfiguration<BlogPostTagEntity>
    {
        public void Configure(EntityTypeBuilder<BlogPostTagEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.ModifiedDate);

            builder.HasOne(x => x.Tag).WithMany(x => x.BlogPostTags).HasForeignKey(x => x.TagId);
            builder.HasOne(x => x.BlogPost).WithMany(x => x.BlogPostTags).HasForeignKey(x => x.BlogPostId);
        }
    }
}
