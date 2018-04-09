using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyBlog.DataAccess.Models;

namespace MyBlog.DataAccess
{
    public class BlogDbContext : DbContext
    {
        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<CategoryModel> Categories { get; set; }
        public virtual DbSet<TagModel> Tags { get; set; }
        public virtual DbSet<PostModel> Posts { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
            // 要先dotnet ef migrations add InitialMigration -o DataAccess/Migrations
            // 否则没有Migrations无法执行dotnet ef database update
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>((m) =>
            {
                m.HasKey(u => u.ID);
                m.Property(u => u.ID).ValueGeneratedOnAdd();
                m.HasIndex(u => u.ID).IsUnique();

                m.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(15);
                m.HasIndex(u => u.Name).IsUnique();
                

                m.Property(u => u.NickName)
                    .HasMaxLength(50);

                m.Property(u => u.Password)
                    .IsRequired()
                    .HasMaxLength(128 / 8);
            });

            modelBuilder.Entity<CategoryModel>((m) =>
            {
                m.HasKey(c => c.ID);
                m.Property(c => c.ID).ValueGeneratedOnAdd();
                m.HasIndex(c => c.ID).IsUnique();

                m.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(10);
                m.HasIndex(c => c.Name).IsUnique();
            });

            modelBuilder.Entity<TagModel>((m) =>
            {
                m.HasKey(t => t.ID);
                m.Property(t => t.ID).ValueGeneratedOnAdd();
                m.HasIndex(t => t.ID).IsUnique();

                m.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(10);
                m.HasIndex(t => t.Name).IsUnique();
            });

            modelBuilder.Entity<TagRelationModel>((m) =>
            {
                m.HasKey(tr => tr.ID);
                m.Property(tr => tr.ID).ValueGeneratedOnAdd();
                m.HasIndex(tr => tr.ID);

                m.HasOne(tr => tr.Post)
                    .WithMany(p => p.TagRelations)
                    .HasForeignKey(tr => tr.PostID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                m.HasOne(tr => tr.Tag)
                    .WithMany(t => t.TagRelations)
                    .HasForeignKey(tr => tr.TagID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PostModel>((m) =>
            {
                m.HasKey(p => p.ID);
                m.Property(p => p.ID).ValueGeneratedOnAdd();
                m.HasIndex(p => p.ID).IsUnique();

                m.Property(p => p.Title)
                    .IsRequired()
                    .HasMaxLength(128);
                
                m.HasOne(p => p.Announcer)
                    .WithMany(u => u.Posts)
                    .HasForeignKey(p => p.AnnouncerID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                
                m.HasOne(p => p.Category)
                    .WithMany(c => c.Posts)
                    .HasForeignKey(p => p.CategoryID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
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
