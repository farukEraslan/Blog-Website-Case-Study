using BlogWebsite.Core.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogWebsite.DataAccess.Config
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CategoryName).HasMaxLength(255);
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.ModifiedDate);

            builder.HasData( new CategoryEntity() { Id = Guid.NewGuid(), CategoryName = "C-Sharp", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now } );
            builder.HasData( new CategoryEntity() { Id = Guid.NewGuid(), CategoryName = "Javascript", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
            builder.HasData( new CategoryEntity() { Id = Guid.NewGuid(), CategoryName = "Phyton", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now });
        }
    }
}
