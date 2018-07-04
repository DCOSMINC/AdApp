﻿// <auto-generated />
using System;
using AdData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdData.Migrations
{
    [DbContext(typeof(AdContext))]
    [Migration("20180704064038_E Migration")]
    partial class EMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdData.Models.Ad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDate");

                    b.Property<int?>("CategoryId");

                    b.Property<int>("CategoryIdVal");

                    b.Property<string>("CommentValue");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime?>("ExpirationDate");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int?>("UserId");

                    b.Property<int>("UserIdVal");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("AdData.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AdData.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdId");

                    b.Property<string>("AddedComment");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("AdData.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("TelephoneNumber")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AdData.Models.Ad", b =>
                {
                    b.HasOne("AdData.Models.Category", "Category")
                        .WithMany("Ads")
                        .HasForeignKey("CategoryId");

                    b.HasOne("AdData.Models.User", "User")
                        .WithMany("Ads")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("AdData.Models.Comment", b =>
                {
                    b.HasOne("AdData.Models.Ad", "Ad")
                        .WithMany("Comments")
                        .HasForeignKey("AdId");

                    b.HasOne("AdData.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
