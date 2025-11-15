using Microsoft.EntityFrameworkCore;
using Day13Lab04.Models;

namespace Day13Lab04.Models
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(serviceProvider
                .GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                context.Database.EnsureCreated();

                // Nếu đã có dữ liệu Major rồi thì không thêm nữa
                if (context.Majors.Any())
                {
                    return;
                }

                // Thêm dữ liệu Majors
                var majors = new Major[]
                {
                    new Major { MajorName = "IT" },
                    new Major { MajorName = "Economics" },
                    new Major { MajorName = "Mathematics" }
                };

                foreach (var major in majors)
                {
                    context.Majors.Add(major);
                }
                context.SaveChanges();

                // Thêm dữ liệu Learners
                var learners = new Learner[]
                {
                    new Learner
                    {
                        FirstMidName = "Carson",
                        LastName = "Alexander",
                        EnrollmentDate = DateTime.Parse("2005-09-01"),
                        MajorID = 1
                    },
                    new Learner
                    {
                        FirstMidName = "Meredith",
                        LastName = "Alonso",
                        EnrollmentDate = DateTime.Parse("2002-09-01"),
                        MajorID = 2
                    }
                };

                foreach (Learner l in learners)
                {
                    context.Learners.Add(l);
                }
                context.SaveChanges();

                // Thêm dữ liệu Courses
                var courses = new Course[]
                {
                    new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                    new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                    new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 }
                };

                foreach (Course c in courses)
                {
                    context.Courses.Add(c);
                }
                context.SaveChanges();

                // Thêm dữ liệu Enrollments
                var enrollments = new Enrollment[]
                {
                    new Enrollment { LearnerID = 1, CourseID = 1050, Grade = 5.5f },
                    new Enrollment { LearnerID = 1, CourseID = 4022, Grade = 7.6f },
                    new Enrollment { LearnerID = 1, CourseID = 1050, Grade = 8.5f }, // Lưu ý: trùng CourseID 1050
                    new Enrollment { LearnerID = 2, CourseID = 4041, Grade = 7f }
                };

                foreach (Enrollment e in enrollments)
                {
                    context.Enrollments.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}