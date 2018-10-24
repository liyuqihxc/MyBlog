using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyBlog.Domain.Entities;

namespace MyBlog.Repository
{
    public class BlogDbContext : DbContext
    {
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<CategoryEntity> Categories { get; set; }
        public virtual DbSet<TagEntity> Tags { get; set; }
        public virtual DbSet<PostEntity> Posts { get; set; }
        public virtual DbSet<PostTagRelationEntity> PostTagRelations { get; set; }
        public virtual DbSet<ImageEntity> Images { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
            // 要先dotnet ef migrations add InitialMigration -o DataAccess/Migrations
            // 否则没有Migrations无法执行dotnet ef database update
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>((m) =>
            {
                m.HasIndex(u => u.UserName).IsUnique();
            });

            modelBuilder.Entity<CategoryEntity>((m) =>
            {
                m.HasIndex(c => c.Name).IsUnique();
            });

            modelBuilder.Entity<TagEntity>((m) =>
            {
                m.HasIndex(t => t.Name).IsUnique();
            });

            modelBuilder.Entity<ImageEntity>((m) =>
            {
                m.HasIndex(im => im.FileName).IsUnique();
            });

            modelBuilder.Entity<PostEntity>((m) =>
            {
                m.HasIndex(p => p.Title).IsUnique();
            });
        }
    }

    public class BloggingContextFactory : Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<BlogDbContext>
    {
        public BlogDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<BlogDbContext>();
            var connectionString = configuration.GetConnectionString("BlogDb");
            builder.UseSqlite(connectionString);
            return new BlogDbContext(builder.Options);
        }
    }
}
