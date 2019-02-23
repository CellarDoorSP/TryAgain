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
    [Migration("20190219091953_FifthCreate")]
    partial class FifthCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Behavior");
                });

            modelBuilder.Entity("WebApplication1.Models.Student", b =>
                {
                    b.Property<string>("StudentName");

                    b.Property<int>("CurrentTotal");

                    b.Property<int>("GraphValue");

                    b.Property<int>("Id");

                    b.Property<int>("LifetimeTotal");

                    b.HasKey("StudentName");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
