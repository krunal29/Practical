﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Practial.Domain;

namespace Practial.Domain.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20200618065049_AddDeleteConstraint")]
    partial class AddDeleteConstraint
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Practial.Domain.Models.Club", b =>
                {
                    b.Property<char>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("character(1)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ClubId");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("Practial.Domain.Models.Department", b =>
                {
                    b.Property<char>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("character(1)");

                    b.Property<decimal>("AnnualBudget")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Practial.Domain.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<char>("ClubId")
                        .HasColumnType("character(1)");

                    b.Property<char>("DepartmentId")
                        .HasColumnType("character(1)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ClubId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Practial.Domain.Models.Employee", b =>
                {
                    b.HasOne("Practial.Domain.Models.Club", "Club")
                        .WithMany("Employees")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Practial.Domain.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
