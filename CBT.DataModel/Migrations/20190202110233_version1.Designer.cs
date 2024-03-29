﻿// <auto-generated />
using System;
using CBT.DataModel.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CBT.DataModel.Migrations
{
    [DbContext(typeof(CBTDbContext))]
    [Migration("20190202110233_version1")]
    partial class version1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CBT.DataModel.Models.ApplicationUserView", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Discriminator");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LastName");

                    b.Property<string>("OtherNames");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("Status");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("AspNetUsersView");
                });

            modelBuilder.Entity("CBT.DataModel.Models.AuditReport", b =>
                {
                    b.Property<int>("AuditReportId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionPerformed")
                        .IsRequired();

                    b.Property<DateTime>("ActionPerformedTime");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("Status");

                    b.Property<string>("SystemIpAddress");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("UserId");

                    b.HasKey("AuditReportId");

                    b.HasIndex("UserId");

                    b.ToTable("AuditReports");
                });

            modelBuilder.Entity("CBT.DataModel.Models.ExamCategory", b =>
                {
                    b.Property<int>("ExamCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("ParentExamCategoryId");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("ExamCategoryId");

                    b.ToTable("ExamCategories");
                });

            modelBuilder.Entity("CBT.DataModel.Models.ExamInstruction", b =>
                {
                    b.Property<int>("ExamInstructionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("ExamInstructionBody");

                    b.Property<string>("ExamInstructionTitle");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("ExamInstructionId");

                    b.ToTable("ExamInstructions");
                });

            modelBuilder.Entity("CBT.DataModel.Models.ExamOption", b =>
                {
                    b.Property<int>("ExamOptionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OptionA");

                    b.Property<string>("OptionB");

                    b.Property<string>("OptionC");

                    b.Property<string>("OptionD");

                    b.Property<string>("OptionE");

                    b.HasKey("ExamOptionId");

                    b.ToTable("ExamOptions");
                });

            modelBuilder.Entity("CBT.DataModel.Models.ExamQuestion", b =>
                {
                    b.Property<int>("ExamQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .IsRequired();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("ExamOptionId");

                    b.Property<int>("ExamTopicId");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("QuestionBody")
                        .IsRequired();

                    b.Property<bool>("QuestionChoice");

                    b.Property<string>("QuestionType");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("ExamQuestionId");

                    b.HasIndex("ExamOptionId")
                        .IsUnique();

                    b.HasIndex("ExamTopicId");

                    b.ToTable("ExamQuestions");
                });

            modelBuilder.Entity("CBT.DataModel.Models.ExamScheduleTime", b =>
                {
                    b.Property<int>("ExamScheduleTimeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("InstructionDays");

                    b.Property<int>("InstructionHours");

                    b.Property<int>("InstructionMins");

                    b.Property<int>("InstructionSeconds");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("ExamScheduleTimeId");

                    b.ToTable("ExamScheduleTimes");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ExamScheduleTime");
                });

            modelBuilder.Entity("CBT.DataModel.Models.ExamSetting", b =>
                {
                    b.Property<int>("ExamSettingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("ExamSettingLookUp")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<bool>("ToggleExamSetting");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("ExamSettingId");

                    b.ToTable("ExamSettings");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ExamSetting");
                });

            modelBuilder.Entity("CBT.DataModel.Models.ExamTopic", b =>
                {
                    b.Property<int>("ExamTopicId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("ExamCategoryId");

                    b.Property<string>("ExamTopicName");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("ExamTopicId");

                    b.HasIndex("ExamCategoryId");

                    b.ToTable("ExamTopics");
                });

            modelBuilder.Entity("CBT.DataModel.Models.PreviousExamInstruction", b =>
                {
                    b.Property<int>("ExamInstructionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("ExamInstructionBody");

                    b.Property<string>("ExamInstructionTitle");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("ExamInstructionId");

                    b.ToTable("PreviousExamInstructions");
                });

            modelBuilder.Entity("CBT.DataModel.Models.PreviousExamQuestion", b =>
                {
                    b.Property<int>("ExamQuestionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .IsRequired();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("ExamTopicId");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("OptionA");

                    b.Property<string>("OptionB");

                    b.Property<string>("OptionC");

                    b.Property<string>("OptionD");

                    b.Property<string>("OptionE");

                    b.Property<bool>("QuestionChoice");

                    b.Property<string>("QuestionType");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("ExamQuestionId");

                    b.HasIndex("ExamTopicId");

                    b.ToTable("PreviousExamQuestions");
                });

            modelBuilder.Entity("CBT.DataModel.Models.PreviousExamSetting", b =>
                {
                    b.Property<int>("ExamSettingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ExamSettingLookUp")
                        .IsRequired();

                    b.Property<string>("GeneratedPassword");

                    b.Property<int>("NumberToBeRegistered");

                    b.Property<int>("Status");

                    b.Property<bool>("ToggleExamSetting");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("ExamSettingId");

                    b.ToTable("PreviousExamSettings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                        new { Id = "2", Name = "UploadedStudent", NormalizedName = "UPLOADEDSTUDENT" },
                        new { Id = "3", Name = "RegisteredStudent", NormalizedName = "REGISTEREDSTUDENT" },
                        new { Id = "4", Name = "SuperAdmin", NormalizedName = "SUPERADMIN" }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CBT.DataModel.Models.ExamInstructionTime", b =>
                {
                    b.HasBaseType("CBT.DataModel.Models.ExamScheduleTime");


                    b.ToTable("ExamInstructionTime");

                    b.HasDiscriminator().HasValue("ExamInstructionTime");
                });

            modelBuilder.Entity("CBT.DataModel.Models.ExamQuestionTime", b =>
                {
                    b.HasBaseType("CBT.DataModel.Models.ExamScheduleTime");


                    b.ToTable("ExamQuestionTime");

                    b.HasDiscriminator().HasValue("ExamQuestionTime");
                });

            modelBuilder.Entity("CBT.DataModel.Models.RegistrationExamSetting", b =>
                {
                    b.HasBaseType("CBT.DataModel.Models.ExamSetting");

                    b.Property<string>("GeneratedPassword");

                    b.Property<int>("NumberFailed");

                    b.Property<int>("NumberRegistered");

                    b.Property<int>("NumberToBeRegistered");

                    b.ToTable("RegistrationExamSetting");

                    b.HasDiscriminator().HasValue("RegistrationExamSetting");
                });

            modelBuilder.Entity("CBT.DataModel.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("ExamCategoryId");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("ImageUrl");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("OtherNames");

                    b.Property<string>("Password");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasIndex("ExamCategoryId");

                    b.ToTable("ApplicationUser");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("CBT.DataModel.Models.AuditReport", b =>
                {
                    b.HasOne("CBT.DataModel.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("CBT.DataModel.Models.ExamQuestion", b =>
                {
                    b.HasOne("CBT.DataModel.Models.ExamOption", "ExamOption")
                        .WithOne("ExamQuestion")
                        .HasForeignKey("CBT.DataModel.Models.ExamQuestion", "ExamOptionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CBT.DataModel.Models.ExamTopic", "ExamTopic")
                        .WithMany("ExamQuestions")
                        .HasForeignKey("ExamTopicId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CBT.DataModel.Models.ExamTopic", b =>
                {
                    b.HasOne("CBT.DataModel.Models.ExamCategory", "ExamCategory")
                        .WithMany("ExamTopics")
                        .HasForeignKey("ExamCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CBT.DataModel.Models.PreviousExamQuestion", b =>
                {
                    b.HasOne("CBT.DataModel.Models.ExamTopic", "ExamTopic")
                        .WithMany("PreviousExamQuestion")
                        .HasForeignKey("ExamTopicId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CBT.DataModel.Models.ApplicationUser", b =>
                {
                    b.HasOne("CBT.DataModel.Models.ExamCategory", "ExamCategory")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("ExamCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
