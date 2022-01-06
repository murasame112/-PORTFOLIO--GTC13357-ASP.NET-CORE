﻿// <auto-generated />
using GTC13357.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GTC13357.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220105111611_05_01_m1")]
    partial class _05_01_m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseCourseTitle", b =>
                {
                    b.Property<int>("CourseTitlesId")
                        .HasColumnType("int");

                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.HasKey("CourseTitlesId", "CoursesId");

                    b.HasIndex("CoursesId");

                    b.ToTable("CourseCourseTitle");
                });

            modelBuilder.Entity("GTC13357.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("GTC13357.Models.CourseTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Author_Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseTypeId")
                        .IsUnique();

                    b.ToTable("CourseTitles");
                });

            modelBuilder.Entity("GTC13357.Models.CourseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Type_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CourseTypes");
                });

            modelBuilder.Entity("CourseCourseTitle", b =>
                {
                    b.HasOne("GTC13357.Models.CourseTitle", null)
                        .WithMany()
                        .HasForeignKey("CourseTitlesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GTC13357.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GTC13357.Models.CourseTitle", b =>
                {
                    b.HasOne("GTC13357.Models.CourseType", "CourseType")
                        .WithOne("CourseTitle")
                        .HasForeignKey("GTC13357.Models.CourseTitle", "CourseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseType");
                });

            modelBuilder.Entity("GTC13357.Models.CourseType", b =>
                {
                    b.Navigation("CourseTitle");
                });
#pragma warning restore 612, 618
        }
    }
}
