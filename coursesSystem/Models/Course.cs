using System.ComponentModel.DataAnnotations;

namespace coursesSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required, StringLength(150)]
        public string Title { get; set; }

        [Range(1, 10)]
        public int Credits { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Navigation
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
