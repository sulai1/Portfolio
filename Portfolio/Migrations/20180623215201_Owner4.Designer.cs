﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portfolio.Areas.Articles.Controllers;

namespace Portfolio.Migrations
{
    [DbContext(typeof(ArticleDbContext))]
    [Migration("20180623215201_Owner4")]
    partial class Owner4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("GroupId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("IdentityUser");
                });

            modelBuilder.Entity("Portfolio.Areas.Articles.Models.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<DateTime>("CreationDate");

                    b.Property<bool>("IsPublic");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("OwnerId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ArticleId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Portfolio.Areas.Articles.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminId")
                        .IsRequired();

                    b.Property<int?>("ArticleId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("ArticleId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Portfolio.Areas.Articles.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticleId");

                    b.Property<string>("Content");

                    b.Property<string>("Example");

                    b.Property<int>("Index");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("SectionId");

                    b.HasIndex("ArticleId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.HasOne("Portfolio.Areas.Articles.Models.Group")
                        .WithMany("Members")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Portfolio.Areas.Articles.Models.Article", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("Portfolio.Areas.Articles.Models.Group", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Portfolio.Areas.Articles.Models.Article")
                        .WithMany("Group")
                        .HasForeignKey("ArticleId");
                });

            modelBuilder.Entity("Portfolio.Areas.Articles.Models.Section", b =>
                {
                    b.HasOne("Portfolio.Areas.Articles.Models.Article", "Article")
                        .WithMany("Sections")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
