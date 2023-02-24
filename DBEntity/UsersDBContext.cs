using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RandomItemsShop.Models;

namespace RandomItemsShop.DBEntity
{
    public partial class UsersDBContext : DbContext
    {
        public UsersDBContext()
        {
        }

        public UsersDBContext(DbContextOptions<UsersDBContext> options)
            : base(options)
        {
        }
            
        
        public virtual DbSet<ShopTable> ShopTable { get; set; } = null!;
        public virtual DbSet<UsersTable> usersTable { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-3IBE8Q2\\SQLEXPRESS;Initial Catalog=usersDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<ShopTable>(entity =>
            {
                entity.ToTable("ShopTable");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("category");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Description)
                    .HasMaxLength(772)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(71)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Price)
                    .HasColumnType("numeric(6, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Title)
                    .HasMaxLength(97)
                    .IsUnicode(false)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<UsersTable>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("user_pk");

                entity.ToTable("usersTable");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
