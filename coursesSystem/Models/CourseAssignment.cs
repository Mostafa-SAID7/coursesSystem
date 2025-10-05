namespace coursesSystem.Models
{
    public class CourseAssignment
    {
        public int CourseAssignmentId { get; set; }

        public int CourseId { get; set; }
        public int InstructorId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
