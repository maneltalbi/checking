﻿// <auto-generated />
using System;
using CheckingSystem1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CheckingSystem1.Migrations
{
    [DbContext(typeof(CheckingSystemDBContext))]
    [Migration("20220219122219_createDatabase")]
    partial class createDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CheckingSystem1.Models.Categories", b =>
                {
                    b.Property<int>("IdCat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCat");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CheckingSystem1.Models.Incidents", b =>
                {
                    b.Property<int>("IdInc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssignementGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BusinessService")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdAgent")
                        .HasColumnType("int");

                    b.Property<int>("IdCat")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("Idadmin")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subcategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UbdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updatedate")
                        .HasColumnType("datetime2");

                    b.Property<string>("priority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInc");

                    b.HasIndex("IdAgent");

                    b.HasIndex("IdCat");

                    b.HasIndex("IdUser");

                    b.HasIndex("Idadmin");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("CheckingSystem1.Models.SubCategories", b =>
                {
                    b.Property<int>("IdSubCat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCat")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSubCat");

                    b.HasIndex("IdCat");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("CheckingSystem1.Models.SupportAgents", b =>
                {
                    b.Property<int>("IdAgent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAgent");

                    b.ToTable("SupportAgents");
                });

            modelBuilder.Entity("CheckingSystem1.Models.Users", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CheckingSystem1.Models.admin", b =>
                {
                    b.Property<int>("IdAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAdmin");

                    b.ToTable("admin");
                });

            modelBuilder.Entity("CheckingSystem1.Models.Incidents", b =>
                {
                    b.HasOne("CheckingSystem1.Models.SupportAgents", "AssignementTo")
                        .WithMany("Incident")
                        .HasForeignKey("IdAgent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CheckingSystem1.Models.Categories", "Category")
                        .WithMany("Incident")
                        .HasForeignKey("IdCat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CheckingSystem1.Models.Users", "Caller")
                        .WithMany("Incident")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CheckingSystem1.Models.admin", "admin")
                        .WithMany("Incident")
                        .HasForeignKey("Idadmin")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("admin");

                    b.Navigation("AssignementTo");

                    b.Navigation("Caller");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CheckingSystem1.Models.SubCategories", b =>
                {
                    b.HasOne("CheckingSystem1.Models.Categories", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("IdCat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CheckingSystem1.Models.Categories", b =>
                {
                    b.Navigation("Incident");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("CheckingSystem1.Models.SupportAgents", b =>
                {
                    b.Navigation("Incident");
                });

            modelBuilder.Entity("CheckingSystem1.Models.Users", b =>
                {
                    b.Navigation("Incident");
                });

            modelBuilder.Entity("CheckingSystem1.Models.admin", b =>
                {
                    b.Navigation("Incident");
                });
#pragma warning restore 612, 618
        }
    }
}
