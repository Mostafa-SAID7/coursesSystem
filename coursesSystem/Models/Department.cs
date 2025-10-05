using System.ComponentModel.DataAnnotations;

namespace coursesSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }= string.Empty;

        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        // Head of Department (Instructor)
        public int? InstructorId { get; set; }
        public virtual Instructor Administrator { get; set; }

        // Navigation
        public virtual ICollection<Course> Courses { get; set; }
    }
}
