﻿// <auto-generated />
using System;
using Achievements.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Achievements.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Achievements.Domain.Models.Achievements.AchievementGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AchievementGroups");
                });

            modelBuilder.Entity("Achievements.Domain.Models.Achievements.AchievementInstance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AchievementTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CheckedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ExpertId")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AchievementTypeId");

                    b.HasIndex("ExpertId");

                    b.HasIndex("UserId");

                    b.ToTable("AchievementInstances");
                });

            modelBuilder.Entity("Achievements.Domain.Models.Achievements.AchievementType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AchievementGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AchievementGroupId");

                    b.ToTable("AchievementTypes");
                });

            modelBuilder.Entity("Achievements.Domain.Models.Achievements.AchievementValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AchievementInstanceId")
                        .HasColumnType("int");

                    b.Property<int?>("ColumnId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AchievementInstanceId");

                    b.HasIndex("ColumnId");

                    b.ToTable("AchievementValues");
                });

            modelBuilder.Entity("Achievements.Domain.Models.Achievements.Column", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AchievementTypeId")
                        .HasColumnType("int");

                    b.Property<byte>("DataType")
                        .HasColumnType("tinyint");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AchievementTypeId");

                    b.ToTable("Columns");
                });

            modelBuilder.Entity("Achievements.Domain.Models.StoredFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Directory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Identifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("StoredFiles");
                });

            modelBuilder.Entity("Achievements.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Role")
                        .HasColumnType("tinyint");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username", "Email")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL AND [Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Achievements.Domain.Models.Achievements.AchievementInstance", b =>
                {
                    b.HasOne("Achievements.Domain.Models.Achievements.AchievementType", "AchievementType")
                        .WithMany()
                        .HasForeignKey("AchievementTypeId");

                    b.HasOne("Achievements.Domain.Models.User", "Expert")
                        .WithMany()
                        .HasForeignKey("ExpertId");

                    b.HasOne("Achievements.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("AchievementType");

                    b.Navigation("Expert");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Achievements.Domain.Models.Achievements.AchievementType", b =>
                {
                    b.HasOne("Achievements.Domain.Models.Achievements.AchievementGroup", "AchievementGroup")
                        .WithMany("Types")
                        .HasForeignKey("AchievementGroupId");

                    b.Navigation("AchievementGroup");
                });

            modelBuilder.Entity("Achievements.Domain.Models.Achievements.AchievementValue", b =>
                {
                    b.HasOne("Achievements.Domain.Models.Achievements.AchievementInstance", "AchievementInstance")
                        .WithMany("Values")
                        .HasForeignKey("AchievementInstanceId");

                    b.HasOne("Achievements.Domain.Models.Achievements.Column", "Column")
                        .WithMany()
                        .HasForeignKey("ColumnId");

                    b.Navigation("AchievementInstance");

                    b.Navigation("Column");
                });

            modelBuilder.Entity("Achievements.Domain.Models.Achievements.Column", b =>
                {
                    b.HasOne("Achievements.Domain.Models.Achievements.AchievementType", "AchievementType")
                        .WithMany("Columns")
                        .HasForeignKey("AchievementTypeId");

                    b.Navigation("AchievementType");
                });

            modelBuilder.Entity("Achievements.Domain.Models.StoredFile", b =>
                {
                    b.HasOne("Achievements.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Achievements.Domain.Models.Achievements.AchievementGroup", b =>
                {
                    b.Navigation("Types");
                });

            modelBuilder.Entity("Achievements.Domain.Models.Achievements.AchievementInstance", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("Achievements.Domain.Models.Achievements.AchievementType", b =>
                {
                    b.Navigation("Columns");
                });
#pragma warning restore 612, 618
        }
    }
}
