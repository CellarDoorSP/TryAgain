﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Behavior", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BehaviorName")
                        .IsRequired();

                    b.Property<string>("StudentName")
                        .IsRequired();

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("StudentName");

                    b.ToTable("Behavior");
                });

            modelBuilder.Entity("WebApplication1.Models.Student", b =>
                {
                    b.Property<string>("StudentName");

                    b.HasKey("StudentName");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WebApplication1.Models.Behavior", b =>
                {
                    b.HasOne("WebApplication1.Models.Student")
                        .WithMany("StudentBehaviors")
                        .HasForeignKey("StudentName")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
