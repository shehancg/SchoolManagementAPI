using CoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.API.Data
{
    public class SchoolManagementContext : DbContext
    {
        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options) : base(options)
        {
        }

        public DbSet<StudentModel> Students { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }
        public DbSet<ClassroomModel> Classrooms { get; set; }
        public DbSet<AllocateSubjectModel> AllocateSubjects { get; set; }
        public DbSet<AllocateClassroomModel> AllocateClassrooms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add any additional configurations here if needed
        }
    }
}
