﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RandomItemsShop.DBEntity;

#nullable disable

namespace RandomItemsShop.Migrations
{
    [DbContext(typeof(UsersDBContext))]
    [Migration("20230223190027_AddColumn")]
    partial class AddColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RandomItemsShop.Models.ShopTable", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("category");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("count");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(772)
                        .IsUnicode(false)
                        .HasColumnType("varchar(772)")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(71)
                        .IsUnicode(false)
                        .HasColumnType("varchar(71)")
                        .HasColumnName("image");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(6,2)")
                        .HasColumnName("price");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(97)
                        .IsUnicode(false)
                        .HasColumnType("varchar(97)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("ShopTable", (string)null);
                });

            modelBuilder.Entity("RandomItemsShop.Models.UsersTable", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(45)
                        .IsUnicode(false)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("password");

                    b.HasKey("Email")
                        .HasName("user_pk");

                    b.ToTable("usersTable", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
