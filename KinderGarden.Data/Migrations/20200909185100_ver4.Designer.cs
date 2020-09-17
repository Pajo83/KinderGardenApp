﻿// <auto-generated />
using System;
using KinderGarden.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KinderGarden.Data.Migrations
{
    [DbContext(typeof(KindergardenDbContext))]
    [Migration("20200909185100_ver4")]
    partial class ver4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KinderGarden.Core.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KindergardenId")
                        .HasColumnType("int");

                    b.Property<int?>("Name")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KindergardenId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("KinderGarden.Core.Kid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Age")
                        .HasColumnType("float");

                    b.Property<DateTime>("AplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("ParentId");

                    b.ToTable("Kids");
                });

            modelBuilder.Entity("KinderGarden.Core.Kindergarden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kindergardens");
                });

            modelBuilder.Entity("KinderGarden.Core.Parents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImeMajka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImeTatko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Municipality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("KinderGarden.Core.Group", b =>
                {
                    b.HasOne("KinderGarden.Core.Kindergarden", "Kindergarden")
                        .WithMany("groups")
                        .HasForeignKey("KindergardenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KinderGarden.Core.Kid", b =>
                {
                    b.HasOne("KinderGarden.Core.Group", "Group")
                        .WithMany("kids")
                        .HasForeignKey("GroupId");

                    b.HasOne("KinderGarden.Core.Parents", "Parent")
                        .WithMany("kids")
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
