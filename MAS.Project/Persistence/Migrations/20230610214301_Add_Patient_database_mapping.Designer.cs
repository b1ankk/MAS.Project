﻿// <auto-generated />
using System;
using MAS.Project.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MAS.Project.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230610214301_Add_Patient_database_mapping")]
    partial class Add_Patient_database_mapping
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("EntitySequence");

            modelBuilder.Entity("MAS.Project.Model.Entity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValueSql("NEXT VALUE FOR [EntitySequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<long>("Id"));

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("MAS.Project.Model.Patient", b =>
                {
                    b.HasBaseType("MAS.Project.Model.Entity");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleNames")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pesel")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("Registered")
                        .HasColumnType("datetime2");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("MAS.Project.Model.Patient", b =>
                {
                    b.OwnsOne("MAS.Project.Model.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<long>("PatientId")
                                .HasColumnType("bigint");

                            b1.Property<string>("ApartmentNumber")
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("StreetNumber")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(6)
                                .HasColumnType("nvarchar(6)");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patient");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
