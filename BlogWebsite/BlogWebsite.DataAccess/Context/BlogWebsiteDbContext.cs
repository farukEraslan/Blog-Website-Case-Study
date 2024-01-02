using BlogWebsite.Core.Concrete;
using BlogWebsite.DataAccess.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsite.DataAccess.Context
{
    public class BlogWebsiteDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
    {
        public BlogWebsiteDbContext(DbContextOptions<BlogWebsiteDbContext> options) : base(options)
        {

        }

        private readonly DbSet<CategoryEntity> CategoryEntities;
        private readonly DbSet<TagEntity> TagEntities;
        private readonly DbSet<BlogPostEntity> BlogPostEntities;
        private readonly DbSet<BlogPostTagEntity> BlogPostTagEntities;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = ISTN36002\\SQLEXPRESS; Database = BlogWebsite; uid = sa; pwd = 123; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryEntityConfiguration());
            builder.ApplyConfiguration(new TagEntityConfiguration());
            builder.ApplyConfiguration(new BlogPostEntityConfiguration());
            builder.ApplyConfiguration(new BlogPostTagEntityConfiguration());
            builder.ApplyConfiguration(new UserEntityConfiguration());
            builder.ApplyConfiguration(new RoleEntityConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
