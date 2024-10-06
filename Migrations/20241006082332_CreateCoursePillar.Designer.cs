﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace educart.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20241006082332_CreateCoursePillar")]
    partial class CreateCoursePillar
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CoursePillar", b =>
                {
                    b.Property<Guid>("CourseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PillarId")
                        .HasColumnType("uuid");

                    b.HasKey("CourseId", "PillarId");

                    b.HasIndex("PillarId");

                    b.ToTable("course_pillar", (string)null);
                });

            modelBuilder.Entity("CourseResource.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<int>("DurationUnit")
                        .HasColumnType("integer");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("course", (string)null);
                });

            modelBuilder.Entity("PillarResource.Pillar", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("pillar", (string)null);
                });

            modelBuilder.Entity("CoursePillar", b =>
                {
                    b.HasOne("CourseResource.Course", null)
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PillarResource.Pillar", null)
                        .WithMany()
                        .HasForeignKey("PillarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
