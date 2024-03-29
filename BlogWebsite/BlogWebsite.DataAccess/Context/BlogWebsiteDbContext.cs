﻿using BlogWebsite.Core.Concrete;
using BlogWebsite.DataAccess.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsite.DataAccess.Context
{
    public class BlogWebsiteDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BlogWebsiteDbContext(DbContextOptions<BlogWebsiteDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<CategoryEntity> CategoryEntity { get; set; }
        public DbSet<TagEntity> TagEntity { get; set; }
        public DbSet<BlogPostEntity> BlogPostEntity { get; set; }
        public DbSet<BlogPostTagEntity> BlogPostTagEntity{ get; set; }

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
