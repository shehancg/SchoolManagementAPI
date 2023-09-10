﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolManagementSystem.API.Data;

namespace CoreWebApi.Migrations
{
    [DbContext(typeof(SchoolManagementContext))]
    partial class SchoolManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreWebApi.Models.AllocateClassroomModel", b =>
                {
                    b.Property<int>("AllocateClassroomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassroomID")
                        .HasColumnType("int");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("AllocateClassroomID");

                    b.HasIndex("ClassroomID");

                    b.HasIndex("TeacherID");

                    b.ToTable("AllocateClassrooms");
                });

            modelBuilder.Entity("CoreWebApi.Models.AllocateSubjectModel", b =>
                {
                    b.Property<int>("AllocateSubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SubjectID")
                        .HasColumnType("int");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("AllocateSubjectID");

                    b.HasIndex("SubjectID");

                    b.HasIndex("TeacherID");

                    b.ToTable("AllocateSubjects");
                });

            modelBuilder.Entity("CoreWebApi.Models.ClassroomModel", b =>
                {
                    b.Property<int>("ClassroomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassroomName")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ClassroomId");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("CoreWebApi.Models.StudentModel", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("ClassroomID")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudentID");

                    b.HasIndex("ClassroomID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CoreWebApi.Models.SubjectModel", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("CoreWebApi.Models.TeacherModel", b =>
                {
                    b.Property<int>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeacherID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("CoreWebApi.Models.AllocateClassroomModel", b =>
                {
                    b.HasOne("CoreWebApi.Models.ClassroomModel", "Classroom")
                        .WithMany("AllocateClassrooms")
                        .HasForeignKey("ClassroomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreWebApi.Models.TeacherModel", "Teacher")
                        .WithMany("AllocateClassrooms")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoreWebApi.Models.AllocateSubjectModel", b =>
                {
                    b.HasOne("CoreWebApi.Models.SubjectModel", "Subject")
                        .WithMany("AllocateSubjects")
                        .HasForeignKey("SubjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoreWebApi.Models.TeacherModel", "Teacher")
                        .WithMany("AllocateSubjects")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CoreWebApi.Models.StudentModel", b =>
                {
                    b.HasOne("CoreWebApi.Models.ClassroomModel", "Classroom")
                        .WithMany("Students")
                        .HasForeignKey("ClassroomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}