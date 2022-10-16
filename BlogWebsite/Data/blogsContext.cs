using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Data.Models;

namespace WebApplication1.Data
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostCategory> PostCategories { get; set; } = null!;
        public virtual DbSet<PostComment> PostComments { get; set; } = null!;
        public virtual DbSet<PostTag> PostTags { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:BlogContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Active).HasColumnType("datetime");

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Summary)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PostCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Post_Category");

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Category_Category");

                entity.HasOne(d => d.Post)
                    .WithMany()
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Category_Post");
            });

            modelBuilder.Entity<PostComment>(entity =>
            {
                entity.ToTable("PostComment");

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostComments)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostComment_Post");
            });

            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Post_Tag");

                entity.HasOne(d => d.Post)
                    .WithMany()
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Tag_Post");

                entity.HasOne(d => d.Tag)
                    .WithMany()
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Tag_Tag");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.Active).HasColumnType("datetime");

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
