using coursesSystem.Models.Enums;

namespace coursesSystem.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public Grade? Grade { get; set; }

        // Navigation
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
