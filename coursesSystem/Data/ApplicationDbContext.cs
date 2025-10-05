using coursesSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace coursesSystem.Data
{
    // IdentityUser is the default, but you can create an AppUser class if needed
    // IdentityUser is the default, but you can create an AppUser class if needed
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for your system
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Student ↔ AppUser (1-to-1)
            modelBuilder.Entity<Student>()
                .HasOne<AppUser>()
                .WithOne(u => u.StudentProfile)
                .HasForeignKey<Student>(s => s.FullName);

            // Instructor ↔ AppUser (1-to-1)
            modelBuilder.Entity<Instructor>()
                .HasOne<AppUser>()
                .WithOne(u => u.InstructorProfile)
                .HasForeignKey<Instructor>(i => i.FullName);

            // Enrollment relationships
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            // Course ↔ Instructor (one-to-many)
            modelBuilder.Entity<Course>()
                .HasOne<Instructor>()
                .WithMany(i => i.Courses)
                .HasForeignKey("InstructorId")
                .IsRequired(false);
        }
    }
}
