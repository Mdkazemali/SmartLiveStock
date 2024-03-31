﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using smartlivestock.Data;

#nullable disable

namespace smartlivestock.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240330222439_addnullablePrectioption")]
    partial class addnullablePrectioption
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("smartlivestock.Models.Advice", b =>
                {
                    b.Property<int>("AdvId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdvId"), 1L, 1);

                    b.Property<DateTime>("AdvDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdvName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdvId");

                    b.ToTable("Advices");
                });

            modelBuilder.Entity("smartlivestock.Models.ChiefComplaint", b =>
                {
                    b.Property<int>("ChiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChiId"), 1L, 1);

                    b.Property<string>("ChiName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UsrName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChiId");

                    b.ToTable("ChiefComplaint");
                });

            modelBuilder.Entity("smartlivestock.Models.Diagnosis", b =>
                {
                    b.Property<int>("DiagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiagId"), 1L, 1);

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiagName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiagId");

                    b.ToTable("Diagnosis");
                });

            modelBuilder.Entity("smartlivestock.Models.Doses", b =>
                {
                    b.Property<int>("DosesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DosesId"), 1L, 1);

                    b.Property<bool>("Afternoon")
                        .HasColumnType("bit");

                    b.Property<int>("Days")
                        .HasColumnType("int");

                    b.Property<DateTime>("DosesDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DosesName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Evening")
                        .HasColumnType("bit");

                    b.Property<bool>("Morning")
                        .HasColumnType("bit");

                    b.Property<string>("UrName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DosesId");

                    b.ToTable("Doses");
                });

            modelBuilder.Entity("smartlivestock.Models.FlowUp", b =>
                {
                    b.Property<int>("FloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FloId"), 1L, 1);

                    b.Property<DateTime>("FloDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FloName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FloId");

                    b.ToTable("FlowUp");
                });

            modelBuilder.Entity("smartlivestock.Models.GeneralExamination", b =>
                {
                    b.Property<int>("GenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenId"), 1L, 1);

                    b.Property<DateTime>("CreateDt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenId");

                    b.ToTable("GeneralExamination");
                });

            modelBuilder.Entity("smartlivestock.Models.Invastigation", b =>
                {
                    b.Property<int>("InvId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InvId"), 1L, 1);

                    b.Property<DateTime>("InvDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InvId");

                    b.ToTable("Invastigations");
                });

            modelBuilder.Entity("smartlivestock.Models.Medicine", b =>
                {
                    b.Property<int>("MedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedId"), 1L, 1);

                    b.Property<DateTime>("MedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedId");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("smartlivestock.Models.Prescription", b =>
                {
                    b.Property<int>("PresId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PresId"), 1L, 1);

                    b.Property<int?>("AdviceId")
                        .HasColumnType("int");

                    b.Property<int?>("ChiefComplaintId")
                        .HasColumnType("int");

                    b.Property<int?>("DiagnosisId")
                        .HasColumnType("int");

                    b.Property<int?>("DosesId")
                        .HasColumnType("int");

                    b.Property<int?>("FlowUpId")
                        .HasColumnType("int");

                    b.Property<int?>("GeneralExaminationId")
                        .HasColumnType("int");

                    b.Property<int?>("InvastigationId")
                        .HasColumnType("int");

                    b.Property<int?>("MedicineId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PresDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PresName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegistrationId")
                        .HasColumnType("int");

                    b.Property<string>("UrName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PresId");

                    b.HasIndex("AdviceId");

                    b.HasIndex("ChiefComplaintId");

                    b.HasIndex("DiagnosisId");

                    b.HasIndex("DosesId");

                    b.HasIndex("FlowUpId");

                    b.HasIndex("GeneralExaminationId");

                    b.HasIndex("InvastigationId");

                    b.HasIndex("MedicineId");

                    b.HasIndex("RegistrationId");

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("smartlivestock.Models.Registration", b =>
                {
                    b.Property<int>("RegiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegiId"), 1L, 1);

                    b.Property<string>("Ages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDAte")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PtnId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsrName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegiId");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("smartlivestock.Models.Trainingvideo", b =>
                {
                    b.Property<int>("vdoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("vdoId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("videoLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("vdoId");

                    b.ToTable("Trainingvideo");
                });

            modelBuilder.Entity("smartlivestock.Models.UserInformation", b =>
                {
                    b.Property<int>("UserinfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserinfoId"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DVMRegiNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Degree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KhamarType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoginId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("NID")
                        .HasColumnType("decimal(20,0)");

                    b.Property<int?>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TranjectionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserinfoId");

                    b.ToTable("UserInformation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("smartlivestock.Models.Prescription", b =>
                {
                    b.HasOne("smartlivestock.Models.Advice", "Advice")
                        .WithMany()
                        .HasForeignKey("AdviceId");

                    b.HasOne("smartlivestock.Models.ChiefComplaint", "ChiefComplaint")
                        .WithMany()
                        .HasForeignKey("ChiefComplaintId");

                    b.HasOne("smartlivestock.Models.Diagnosis", "Diagnosis")
                        .WithMany()
                        .HasForeignKey("DiagnosisId");

                    b.HasOne("smartlivestock.Models.Doses", "Doses")
                        .WithMany()
                        .HasForeignKey("DosesId");

                    b.HasOne("smartlivestock.Models.FlowUp", "FlowUp")
                        .WithMany()
                        .HasForeignKey("FlowUpId");

                    b.HasOne("smartlivestock.Models.GeneralExamination", "GeneralExamination")
                        .WithMany()
                        .HasForeignKey("GeneralExaminationId");

                    b.HasOne("smartlivestock.Models.Invastigation", "Invastigation")
                        .WithMany()
                        .HasForeignKey("InvastigationId");

                    b.HasOne("smartlivestock.Models.Medicine", "Medicine")
                        .WithMany()
                        .HasForeignKey("MedicineId");

                    b.HasOne("smartlivestock.Models.Registration", "Registration")
                        .WithMany()
                        .HasForeignKey("RegistrationId");

                    b.Navigation("Advice");

                    b.Navigation("ChiefComplaint");

                    b.Navigation("Diagnosis");

                    b.Navigation("Doses");

                    b.Navigation("FlowUp");

                    b.Navigation("GeneralExamination");

                    b.Navigation("Invastigation");

                    b.Navigation("Medicine");

                    b.Navigation("Registration");
                });
#pragma warning restore 612, 618
        }
    }
}
