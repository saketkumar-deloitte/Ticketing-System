﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ticketing_System.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20230227045230_third")]
    partial class third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Issue", b =>
                {
                    b.Property<int>("issueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AssigneeId")
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

                    b.Property<int?>("projectId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("updateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("issueId");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("ReporterId");

                    b.HasIndex("projectId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("IssueLabel", b =>
                {
                    b.Property<int>("issueId")
                        .HasColumnType("int");

                    b.Property<int>("listLabellabelId")
                        .HasColumnType("int");

                    b.HasKey("issueId", "listLabellabelId");

                    b.HasIndex("listLabellabelId");

                    b.ToTable("IssueLabel");
                });

            modelBuilder.Entity("Label", b =>
                {
                    b.Property<int>("labelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("labelId");

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

                    b.Property<string>("designation")
                        .IsRequired()
                        .HasColumnType("longtext");

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
                        .WithMany("Assignee")
                        .HasForeignKey("AssigneeId");

                    b.HasOne("Ticketing_System.Models.User", "Reporter")
                        .WithMany("Reporter")
                        .HasForeignKey("ReporterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project", "Project")
                        .WithMany("issueList")
                        .HasForeignKey("projectId");

                    b.Navigation("Assignee");

                    b.Navigation("Project");

                    b.Navigation("Reporter");
                });

            modelBuilder.Entity("IssueLabel", b =>
                {
                    b.HasOne("Issue", null)
                        .WithMany()
                        .HasForeignKey("issueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Label", null)
                        .WithMany()
                        .HasForeignKey("listLabellabelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("Project", b =>
                {
                    b.Navigation("issueList");
                });

            modelBuilder.Entity("Ticketing_System.Models.User", b =>
                {
                    b.Navigation("Assignee");

                    b.Navigation("Reporter");

                    b.Navigation("projectsList");
                });
#pragma warning restore 612, 618
        }
    }
}
