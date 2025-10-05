using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace coursesSystem.Models
{
    public class AppUser : IdentityUser
    {
        [Required, StringLength(150)]
        public string FullName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public bool IsInstructor { get; set; }

        // Navigation
        public virtual Student StudentProfile { get; set; }
        public virtual Instructor InstructorProfile { get; set; }
    }
}
