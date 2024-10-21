﻿// <auto-generated />
using System;
using ASDP.FinalProject.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ASDP.FinalProject.Migrations
{
    [DbContext(typeof(AdspContext))]
    [Migration("20241020171258_fix_SignDocument_DateTime")]
    partial class fix_SignDocument_DateTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("IdentityIssueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IdentityIssuer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Iin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PositionId")
                        .HasColumnType("integer");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 1,
                            Name = "Подпись документов"
                        });
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 1,
                            Name = "Сотрудник"
                        },
                        new
                        {
                            Id = 2,
                            Code = 2,
                            Name = "Тимлид"
                        },
                        new
                        {
                            Id = 3,
                            Code = 3,
                            Name = "Директор"
                        });
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.PositionPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer");

                    b.Property<int>("PositionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("PositionId");

                    b.ToTable("PositionPermission", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PermissionId = 1,
                            PositionId = 2
                        },
                        new
                        {
                            Id = 2,
                            PermissionId = 1,
                            PositionId = 3
                        });
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.SignDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<DateTime>("IndexDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SigexDocumentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SignPipelineId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SignPipelineId")
                        .IsUnique();

                    b.ToTable("SignDocuments");
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.SignPipeline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CreatorEmployeeId")
                        .HasColumnType("integer");

                    b.Property<long>("SigexSignId")
                        .HasColumnType("bigint");

                    b.Property<Guid>("SignDocumentId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CreatorEmployeeId");

                    b.ToTable("SignPipeline");
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.SignerToPipeline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsSigned")
                        .HasColumnType("boolean");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<Guid>("SignPipelineId")
                        .HasColumnType("uuid");

                    b.Property<int>("SignerEmployeeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SignPipelineId");

                    b.HasIndex("SignerEmployeeId");

                    b.ToTable("SignerToPipeline");
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.Template", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<DateTimeOffset>("IndexDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.Employee", b =>
                {
                    b.HasOne("ASDP.FinalProject.DAL.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.PositionPermission", b =>
                {
                    b.HasOne("ASDP.FinalProject.DAL.Models.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ASDP.FinalProject.DAL.Models.Position", "Position")
                        .WithMany("Permissions")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.SignDocument", b =>
                {
                    b.HasOne("ASDP.FinalProject.DAL.Models.SignPipeline", "SignPipeline")
                        .WithOne("SignDocument")
                        .HasForeignKey("ASDP.FinalProject.DAL.Models.SignDocument", "SignPipelineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SignPipeline");
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.SignPipeline", b =>
                {
                    b.HasOne("ASDP.FinalProject.DAL.Models.Employee", "CreatorEmployee")
                        .WithMany("CreatedSignPipelines")
                        .HasForeignKey("CreatorEmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatorEmployee");
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.SignerToPipeline", b =>
                {
                    b.HasOne("ASDP.FinalProject.DAL.Models.SignPipeline", "SignPipeline")
                        .WithMany("Signers")
                        .HasForeignKey("SignPipelineId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ASDP.FinalProject.DAL.Models.Employee", "SignerEmployee")
                        .WithMany("PipelinesToSign")
                        .HasForeignKey("SignerEmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SignPipeline");

                    b.Navigation("SignerEmployee");
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.Employee", b =>
                {
                    b.Navigation("CreatedSignPipelines");

                    b.Navigation("PipelinesToSign");
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.Position", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("ASDP.FinalProject.DAL.Models.SignPipeline", b =>
                {
                    b.Navigation("SignDocument")
                        .IsRequired();

                    b.Navigation("Signers");
                });
#pragma warning restore 612, 618
        }
    }
}
