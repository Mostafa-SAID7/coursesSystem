using System.ComponentModel.DataAnnotations;

namespace coursesSystem.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        public DateTime HireDate { get; set; } = DateTime.Now;

        // Link to Identity user
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
