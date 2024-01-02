using BlogWebsite.Core.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogWebsite.DataAccess.Config
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasData( new RoleEntity() { Id = Guid.NewGuid(), Name = "Admin"});
            builder.HasData( new RoleEntity() { Id = Guid.NewGuid(), Name = "Author"});
        }
    }
}
