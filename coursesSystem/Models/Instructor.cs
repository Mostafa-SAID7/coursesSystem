using System.ComponentModel.DataAnnotations;

namespace coursesSystem.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }

        [Required, StringLength(50)]
        public string EmployeeNumber { get; set; } // e.g. "EMP-2024001"

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; } = DateTime.Now;

        // Link to Identity User
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        // Navigation
        public virtual ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
