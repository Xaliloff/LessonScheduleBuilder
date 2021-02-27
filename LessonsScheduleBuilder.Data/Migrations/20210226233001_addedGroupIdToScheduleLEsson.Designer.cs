﻿// <auto-generated />
using System;
using LessonsScheduleBuilder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LessonsScheduleBuilder.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210226233001_addedGroupIdToScheduleLEsson")]
    partial class addedGroupIdToScheduleLEsson
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LessonsScheduleBuilder.Data.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Grade")
                        .HasColumnType("smallint");

                    b.Property<string>("GroupSuffix")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("LessonsScheduleBuilder.Data.Models.LessonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("LessonTypes");
                });

            modelBuilder.Entity("LessonsScheduleBuilder.Data.Models.ScheduleLesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("LessonTime")
                        .HasColumnType("time");

                    b.Property<int>("LessonTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SelectedTeacherId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("LessonTypeId");

                    b.HasIndex("SelectedTeacherId");

                    b.ToTable("ScheduleLessons");
                });

            modelBuilder.Entity("LessonsScheduleBuilder.Data.Models.TeacherSpecialization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LessonTypeId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonTypeId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherSpecializations");
                });

            modelBuilder.Entity("LessonsScheduleBuilder.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("LessonsScheduleBuilder.Data.Models.Student", b =>
                {
                    b.HasBaseType("LessonsScheduleBuilder.Data.Models.User");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasIndex("GroupId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("LessonsScheduleBuilder.Data.Models.Teacher", b =>
                {
                    b.HasBaseType("LessonsScheduleBuilder.Data.Models.User");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("LessonsScheduleBuilder.Data.Models.ScheduleLesson", b =>
                {
                    b.HasOne("LessonsScheduleBuilder.Data.Models.Group", "Group")
                        .WithMany("ScheduleLessons")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("LessonsScheduleBuilder.Data.Models.LessonType", "LessonType")
                        .WithMany()
                        .HasForeignKey("LessonTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LessonsScheduleBuilder.Data.Models.Teacher", "SelectedTeacher")
                        .WithMany()
                        .HasForeignKey("SelectedTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("LessonType");

                    b.Navigation("SelectedTeacher");
                });

            modelBuilder.Entity("LessonsScheduleBuilder.Data.Models.TeacherSpecialization", b =>
                {
                    b.HasOne("LessonsScheduleBuilder.Data.Models.LessonType", "LessonType")
                        .WithMany()
                        .HasForeignKey("LessonTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LessonsScheduleBuilder.Data.Models.Teacher", "Teacher")
                        .WithMany("Specializations")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LessonType");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("LessonsScheduleBuilder.Data.Models.Student", b =>
                {
                    b.HasOne("LessonsScheduleBuilder.Data.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("LessonsScheduleBuilder.Data.Models.Group", b =>
                {
                    b.Navigation("ScheduleLessons");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("LessonsScheduleBuilder.Data.Models.Teacher", b =>
                {
                    b.Navigation("Specializations");
                });
#pragma warning restore 612, 618
        }
    }
}