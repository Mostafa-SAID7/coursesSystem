using coursesSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace coursesSystem.Data.Seeds
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(
            ApplicationDbContext context,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Apply migrations
            await context.Database.MigrateAsync();

            // 1. Create Roles
            string[] roles = { "Admin", "Instructor", "Student" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // 2. Create Admin User
            var adminUser = await userManager.FindByEmailAsync("admin@system.com");
            if (adminUser == null)
            {
                adminUser = new AppUser
                {
                    UserName = "admin@system.com",
                    Email = "admin@system.com",
                    FullName = "System Administrator",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(adminUser, "Admin123!");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // 3. Seed Instructor
            if (!context.Instructors.Any(i => i.EmployeeNumber == "EMP-1001"))
            {
                var instructorUser = await userManager.FindByEmailAsync("jane.doe@school.com");
                if (instructorUser == null)
                {
                    instructorUser = new AppUser
                    {
                        UserName = "jane.doe@school.com",
                        Email = "jane.doe@school.com",
                        FullName = "Jane Doe",
                        IsInstructor = true,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(instructorUser, "Password123!");
                    await userManager.AddToRoleAsync(instructorUser, "Instructor");
                }

                var instructor = new Instructor
                {
                    EmployeeNumber = "EMP-1001",
                    HireDate = DateTime.Now.AddYears(-5),
                    AppUserId = instructorUser.Id
                };

                context.Instructors.Add(instructor);
                await context.SaveChangesAsync();
            }

            // 4. Seed Student
            if (!context.Students.Any(s => s.StudentNumber == "STU-2001"))
            {
                var studentUser = await userManager.FindByEmailAsync("john.student@school.com");
                if (studentUser == null)
                {
                    studentUser = new AppUser
                    {
                        UserName = "john.student@school.com",
                        Email = "john.student@school.com",
                        FullName = "John Student",
                        IsInstructor = false,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(studentUser, "Password123!");
                    await userManager.AddToRoleAsync(studentUser, "Student");
                }

                var student = new Student
                {
                    StudentNumber = "STU-2001",
                    EnrollmentDate = DateTime.Now.AddYears(-1),
                    AppUserId = studentUser.Id
                };

                context.Students.Add(student);
                await context.SaveChangesAsync();
            }

            // 5. Seed Department & Courses
            if (!context.Departments.Any(d => d.Name == "Computer Science"))
            {
                var dept = new Department
                {
                    Name = "Computer Science",
                    Budget = 500000,
                    StartDate = DateTime.Now.AddYears(-10)
                };
                context.Departments.Add(dept);
                await context.SaveChangesAsync();

                var course1 = new Course
                {
                    Title = "Introduction to Programming",
                    Credits = 3,
                    Description = "Learn the basics of C# and .NET"
                };

                var course2 = new Course
                {
                    Title = "Databases 101",
                    Credits = 4,
                    Description = "Fundamentals of SQL and relational databases"
                };

                context.Courses.AddRange(course1, course2);
                await context.SaveChangesAsync();
            }
        }
    }
}
