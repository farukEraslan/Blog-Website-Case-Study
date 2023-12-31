using BlogWebsite.Core.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsite.DataAccess.Config
{
    public class BlogWebsiteDbContext : IdentityDbContext
    {
        private readonly DbSet<AdminEntity> AdminEntities;
        private readonly DbSet<AuthorEntity> AuthorEntities;
        private readonly DbSet<CategoryEntity> CategoryEntities;
        private readonly DbSet<TagEntity> TagEntities;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ISTN36002\\SQLEXPRESS; Database=BlogWebsite; uid=sa; pwd=123; Trusted_Connection=True; MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
