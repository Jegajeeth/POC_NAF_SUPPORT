﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NAFSupport.Server.DataAccessLayer;

#nullable disable

namespace NAFSupport.Server.Migrations
{
    [DbContext(typeof(NAFSupportDBContext))]
    [Migration("20230919065727_migsupport")]
    partial class migsupport
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NAFSupport.Shared.Models.Department", b =>
                {
                    b.Property<int>("departmentRefId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("departmentRefId"));

                    b.Property<string>("departmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("departmentRefId");

                    b.ToTable("department");
                });

            modelBuilder.Entity("NAFSupport.Shared.Models.Role", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleId"));

                    b.Property<string>("roleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleId");

                    b.ToTable("role");
                });

            modelBuilder.Entity("NAFSupport.Shared.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("assignedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("createdBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("endDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("priority")
                        .HasColumnType("int");

                    b.Property<int>("severity")
                        .HasColumnType("int");

                    b.Property<string>("startDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("ticketId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tickets");
                });

            modelBuilder.Entity("NAFSupport.Shared.Models.TicketStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ticketStatus");
                });

            modelBuilder.Entity("NAFSupport.Shared.Models.UserDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("departmentRefId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("roleId")
                        .HasColumnType("int");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("userDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
