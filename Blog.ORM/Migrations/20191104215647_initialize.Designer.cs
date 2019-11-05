﻿// <auto-generated />
using System;

using Blog.ORM.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.ORM.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20191104215647_initialize")]
    partial class initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.ORM.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Author");

                    b.Property<string>("Body");

                    b.Property<string>("Category");

                    b.Property<DateTime>("CreateDate");

                    b.Property<TimeSpan>("ReadingTime");

                    b.Property<string>("Title");

                    b.Property<Guid?>("UserId");

                    b.HasKey("PostId");

                    b.HasIndex("Author");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Blog.ORM.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<DateTime>("RegisteredAt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Blog.ORM.Models.Post", b =>
                {
                    b.HasOne("Blog.ORM.Models.User")
                        .WithMany("Posts")
                        .HasForeignKey("Author")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Blog.ORM.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
