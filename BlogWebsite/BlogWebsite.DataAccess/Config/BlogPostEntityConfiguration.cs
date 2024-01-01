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
    internal class BlogPostEntityConfiguration : IEntityTypeConfiguration<BlogPostEntity>
    {
        public void Configure(EntityTypeBuilder<BlogPostEntity> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Header).HasMaxLength(255);
            builder.Property(x => x.Content);
            builder.Property(x => x.Status);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.ModifiedDate);

            builder.HasOne(x=>x.User).WithMany(x=>x.BlogPosts).HasForeignKey(x=>x.UserId);
            builder.HasOne(x=>x.Category).WithMany(x=>x.BlogPosts).HasForeignKey(x=>x.CategoryId);
        }
    }
}
