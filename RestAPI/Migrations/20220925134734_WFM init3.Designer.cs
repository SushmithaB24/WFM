﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestAPI.Models;

#nullable disable

namespace RestAPI.Migrations
{
    [DbContext(typeof(RestAPIDBContext))]
    [Migration("20220925134734_WFM init3")]
    partial class WFMinit3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RestAPI.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal?>("Experience")
                        .HasPrecision(5)
                        .HasColumnType("decimal(5,0)");

                    b.Property<string>("LockStatus")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Manager")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("WfmManager")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("RestAPI.Models.SkillMap", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("Skillid")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("Skillid");

                    b.ToTable("SkillMaps", (string)null);
                });

            modelBuilder.Entity("RestAPI.Models.Skills", b =>
                {
                    b.Property<int>("Skillid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Skillid"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Skillid");

                    b.ToTable("Skills", (string)null);
                });

            modelBuilder.Entity("RestAPI.Models.SkillMap", b =>
                {
                    b.HasOne("RestAPI.Models.Employee", "Employee")
                        .WithMany("SkillMaps")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RestAPI.Models.Skills", "Skills")
                        .WithMany("SkillMaps")
                        .HasForeignKey("Skillid")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Employee");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("RestAPI.Models.Employee", b =>
                {
                    b.Navigation("SkillMaps");
                });

            modelBuilder.Entity("RestAPI.Models.Skills", b =>
                {
                    b.Navigation("SkillMaps");
                });
#pragma warning restore 612, 618
        }
    }
}
