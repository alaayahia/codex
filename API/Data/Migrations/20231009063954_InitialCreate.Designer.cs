﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231009063954_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte>("PasswordHash")
                        .HasColumnType("tinyint");

                    b.Property<byte>("PasswordSalt")
                        .HasColumnType("tinyint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Entities.Compensation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompEquation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAffected")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModify")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Compensations");
                });

            modelBuilder.Entity("API.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmpPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("JopDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModify")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("API.Entities.EmployeeCompensation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompId")
                        .HasColumnType("int");

                    b.Property<double>("CompValue")
                        .HasColumnType("float");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModify")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartFrom")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompId");

                    b.HasIndex("EmpId");

                    b.ToTable("EmployeeCompensations");
                });

            modelBuilder.Entity("API.Entities.EmployeeDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModify")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmpId");

                    b.ToTable("EmployeeDocuments");
                });

            modelBuilder.Entity("API.Entities.EmployeeCompensation", b =>
                {
                    b.HasOne("API.Entities.Compensation", "Compensation")
                        .WithMany("EmployeeCompensations")
                        .HasForeignKey("CompId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("API.Entities.Employee", "Employee")
                        .WithMany("EmployeeCompensations")
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Compensation");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Entities.EmployeeDocument", b =>
                {
                    b.HasOne("API.Entities.Employee", "Employee")
                        .WithMany("EmployeeDocuments")
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Entities.Compensation", b =>
                {
                    b.Navigation("EmployeeCompensations");
                });

            modelBuilder.Entity("API.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeCompensations");

                    b.Navigation("EmployeeDocuments");
                });
#pragma warning restore 612, 618
        }
    }
}