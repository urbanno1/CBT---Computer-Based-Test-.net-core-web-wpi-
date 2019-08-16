using CBT.DataModel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CBT.DataModel.DataModel
{
    public class CBTDbContext : IdentityDbContext<IdentityUser>
    {
        public CBTDbContext(DbContextOptions<CBTDbContext> option) : base(option) { }

        // The model classes
        public DbSet<ExamOption> ExamOptions { get; set; }
        public DbSet<ExamTopic> ExamTopics { get; set; }
        public DbSet<ApplicationUserView> ApplicationUserViews { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        public DbSet<PreviousExamQuestion> PreviousExamQuestions { get; set; }
        public DbSet<ExamCategory> ExamCategories { get; set; }
        public DbSet<AuditReport> AuditReports { get; set; }
        public DbSet<ExamInstruction> ExamInstructions { get; set; }
        public DbSet<PreviousExamInstruction> PreviousExamInstructions { get; set; }
        public DbSet<ExamScheduleTime> ExamScheduleTimes { get; set; }
        public DbSet<ExamQuestionTime> ExamQuestionTimes { get; set; }
        public DbSet<ExamInstructionTime> ExamInstructionTimes { get; set; }
        public DbSet<ExamSetting> ExamSettings { get; set; }
        public DbSet<RegistrationExamSetting> RegistrationExamSettings { get; set; }
        public DbSet<PreviousExamSetting> PreviousExamSettings { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Seed Data for Role Management
            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "UploadedStudent", NormalizedName = "UPLOADEDSTUDENT" },
                new { Id = "3", Name = "RegisteredStudent", NormalizedName = "REGISTEREDSTUDENT" },
                new { Id = "4", Name = "SuperAdmin", NormalizedName = "SUPERADMIN" }
                );
            #endregion

            builder.Entity<ApplicationUserView>().HasKey(c => c.Id);
            builder.Entity<ApplicationUserView>().ToTable("AspNetUsersView");

        }
    }
}
