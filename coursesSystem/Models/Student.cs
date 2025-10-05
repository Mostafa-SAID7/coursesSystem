using System.ComponentModel.DataAnnotations;

namespace coursesSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required, StringLength(50)]
        public string StudentNumber { get; set; } // e.g. "STU-2025001"

        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        // Link to Identity User
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        // Navigation
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
