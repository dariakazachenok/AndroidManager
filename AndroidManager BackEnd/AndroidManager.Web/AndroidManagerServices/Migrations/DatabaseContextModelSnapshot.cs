﻿// <auto-generated />
using System;
using AndroidManager.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AndroidManagerServices.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AndroidManager.Web.Android", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AndroidName");

                    b.Property<string>("AvatarImage");

                    b.Property<int>("Reliability");

                    b.Property<string>("Skills");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.ToTable("Androids");
                });

            modelBuilder.Entity("AndroidManager.Web.AndroidJob", b =>
                {
                    b.Property<int>("AndroidId");

                    b.Property<int>("JobId");

                    b.HasKey("AndroidId", "JobId");

                    b.HasIndex("JobId");

                    b.ToTable("AndroidJob");
                });

            modelBuilder.Entity("AndroidManager.Web.Job", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComplexityLevel");

                    b.Property<string>("Description");

                    b.Property<string>("JobName");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("AndroidManager.Web.AndroidJob", b =>
                {
                    b.HasOne("AndroidManager.Web.Android", "Android")
                        .WithMany("AndroidJobs")
                        .HasForeignKey("AndroidId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AndroidManager.Web.Job", "Job")
                        .WithMany("AndroidJobs")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
