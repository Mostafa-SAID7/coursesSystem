using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace coursesSystem.Models
{
    public class AppUser : IdentityUser
    {
        [Required, StringLength(100)]
        public string FullName { get; set; }

        // Optional: flag to mark if user is an instructor or student
        public bool IsInstructor { get; set; }

        // Navigation properties
        public virtual Student StudentProfile { get; set; }
        public virtual Instructor InstructorProfile { get; set; }
    }
}
