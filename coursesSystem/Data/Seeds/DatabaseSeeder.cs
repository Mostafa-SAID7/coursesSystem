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
            if (await userManager.FindByEmailAsync("admin@system.com") == null)
            {
                var admin = new AppUser
                {
                    UserName = "admin@system.com",
                    Email = "admin@system.com",
                    FullName = "System Administrator",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            // 3. Seed Instructors
            if (!context.Instructors.Any())
            {
                var instructor1User = new AppUser
                {
                    UserName = "jane.doe@school.com",
                    Email = "jane.doe@school.com",
                    FullName = "Jane Doe",
                    IsInstructor = true,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(instructor1User, "Password123!");
                await userManager.AddToRoleAsync(instructor1User, "Instructor");

                var instructor1 = new Instructor
                {
                    EmployeeNumber = "EMP-1001",
                    HireDate = DateTime.Now.AddYears(-5),
                    AppUserId = instructor1User.Id
                };

                context.Instructors.Add(instructor1);
                await context.SaveChangesAsync();
            }

            // 4. Seed Students
            if (!context.Students.Any())
            {
                var student1User = new AppUser
                {
                    UserName = "john.student@school.com",
                    Email = "john.student@school.com",
                    FullName = "John Student",
                    IsInstructor = false,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(student1User, "Password123!");
                await userManager.AddToRoleAsync(student1User, "Student");

                var student1 = new Student
                {
                    StudentNumber = "STU-2001",
                    EnrollmentDate = DateTime.Now.AddYears(-1),
                    AppUserId = student1User.Id
                };

                context.Students.Add(student1);
                await context.SaveChangesAsync();
            }

            // 5. Seed Departments and Courses
            if (!context.Departments.Any())
            {
                var dept = new Department
                {
                    Name = "Computer Science",
                    Budget = 500000,
                    StartDate = DateTime.Now.AddYears(-10),
                };
                context.Departments.Add(dept);
                await context.SaveChangesAsync();

                var course1 = new Course
                {
                    Title = "Introduction to Programming",
                    Credits = 3,
                    Description = "Learn the basics of C# and .NET",
                };

                var course2 = new Course
                {
                    Title = "Databases 101",
                    Credits = 4,
                    Description = "Fundamentals of SQL and relational databases",
                };

                context.Courses.AddRange(course1, course2);
                await context.SaveChangesAsync();
            }
        }
    }
}
