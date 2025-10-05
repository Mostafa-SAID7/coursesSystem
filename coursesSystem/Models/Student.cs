using System.ComponentModel.DataAnnotations;

namespace coursesSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        // Link to Identity user
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
