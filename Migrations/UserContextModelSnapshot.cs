﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ticketing_System.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Issue", b =>
                {
                    b.Property<int>("AssigneeId")
                        .HasColumnType("int");

                    b.Property<int>("ReporterId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("createDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("issueId")
                        .HasColumnType("int");

                    b.Property<int>("projectId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("updateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("AssigneeId", "ReporterId");

                    b.HasIndex("AssigneeId")
                        .IsUnique();

                    b.HasIndex("ReporterId")
                        .IsUnique();

                    b.HasIndex("projectId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Label", b =>
                {
                    b.Property<int>("labelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("issueAssigneeId")
                        .HasColumnType("int");

                    b.Property<int>("issueReporterId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("labelId");

                    b.HasIndex("issueAssigneeId", "issueReporterId");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("Project", b =>
                {
                    b.Property<int>("projectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("creatoruserId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("projectId");

                    b.HasIndex("creatoruserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("rolesListroleId")
                        .HasColumnType("int");

                    b.Property<int>("usersListuserId")
                        .HasColumnType("int");

                    b.HasKey("rolesListroleId", "usersListuserId");

                    b.HasIndex("usersListuserId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("Ticketing_System.Models.Role", b =>
                {
                    b.Property<int>("roleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("roleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Ticketing_System.Models.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Issue", b =>
                {
                    b.HasOne("Ticketing_System.Models.User", "Assignee")
                        .WithOne("Assignee")
                        .HasForeignKey("Issue", "AssigneeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ticketing_System.Models.User", "Reporter")
                        .WithOne("Reporter")
                        .HasForeignKey("Issue", "ReporterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Project", "Project")
                        .WithMany("issueList")
                        .HasForeignKey("projectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignee");

                    b.Navigation("Project");

                    b.Navigation("Reporter");
                });

            modelBuilder.Entity("Label", b =>
                {
                    b.HasOne("Issue", "issue")
                        .WithMany("listLabel")
                        .HasForeignKey("issueAssigneeId", "issueReporterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("issue");
                });

            modelBuilder.Entity("Project", b =>
                {
                    b.HasOne("Ticketing_System.Models.User", "creator")
                        .WithMany("projectsList")
                        .HasForeignKey("creatoruserId");

                    b.Navigation("creator");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("Ticketing_System.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("rolesListroleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ticketing_System.Models.User", null)
                        .WithMany()
                        .HasForeignKey("usersListuserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Issue", b =>
                {
                    b.Navigation("listLabel");
                });

            modelBuilder.Entity("Project", b =>
                {
                    b.Navigation("issueList");
                });

            modelBuilder.Entity("Ticketing_System.Models.User", b =>
                {
                    b.Navigation("Assignee")
                        .IsRequired();

                    b.Navigation("Reporter")
                        .IsRequired();

                    b.Navigation("projectsList");
                });
#pragma warning restore 612, 618
        }
    }
}
