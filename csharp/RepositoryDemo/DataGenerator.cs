using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RepositoryDemo.Models;

namespace RepositoryDemo
{
    public static class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(
                serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                context.Database.EnsureCreated();
                
                if (context.Students.Any())
                {
                    return;
                }

                var students = new List<Student>
                {
                    new Student
                    {
                        FirstName = "Carson", LastName = "Alexander",
                        EnrollmentDate = DateTime.Parse("2010-09-01")
                    },
                    new Student
                    {
                        FirstName = "Meredith", LastName = "Alonso",
                        EnrollmentDate = DateTime.Parse("2012-09-01")
                    },
                    new Student
                    {
                        FirstName = "Arturo", LastName = "Anand",
                        EnrollmentDate = DateTime.Parse("2013-09-01")
                    },
                    new Student
                    {
                        FirstName = "Gytis", LastName = "Barzdukas",
                        EnrollmentDate = DateTime.Parse("2012-09-01")
                    },
                    new Student
                    {
                        FirstName = "Yan", LastName = "Li",
                        EnrollmentDate = DateTime.Parse("2012-09-01")
                    },
                    new Student
                    {
                        FirstName = "Peggy", LastName = "Justice",
                        EnrollmentDate = DateTime.Parse("2011-09-01")
                    },
                    new Student
                    {
                        FirstName = "Laura", LastName = "Norman",
                        EnrollmentDate = DateTime.Parse("2013-09-01")
                    },
                    new Student
                    {
                        FirstName = "Nino", LastName = "Olivetto",
                        EnrollmentDate = DateTime.Parse("2005-08-11")
                    }
                };

                context.AddRange(students);
                context.SaveChanges();

                var courses = new List<Course>
                {
                    new Course {Title = "Chemistry", Credits = 3,},
                    new Course {Title = "Microeconomics", Credits = 3,},
                    new Course {Title = "Macroeconomics", Credits = 3,},
                    new Course {Title = "Calculus", Credits = 4,},
                    new Course {Title = "Trigonometry", Credits = 4,},
                    new Course {Title = "Composition", Credits = 3,},
                    new Course {Title = "Literature", Credits = 4,}
                };

                context.AddRange(courses);
                context.SaveChanges();

                var enrollments = new List<Enrollment>
                {
                    new Enrollment
                    {
                        StudentId = students[0].StudentId,
                        Course = courses[0],
                        Grade = 1
                    },
                    new Enrollment
                    {
                        StudentId = students[0].StudentId,
                        Course = courses[1],
                        Grade = 3
                    },
                    new Enrollment
                    {
                        StudentId = students[0].StudentId,
                        Course = courses[2],
                        Grade = 2
                    },
                    new Enrollment
                    {
                        StudentId = students[1].StudentId,
                        Course = courses[3],
                        Grade = 2
                    },
                    new Enrollment
                    {
                        StudentId = students[1].StudentId,
                        Course = courses[4],
                        Grade = 2
                    },
                    new Enrollment
                    {
                        StudentId = students[1].StudentId,
                        Course = courses[5],
                        Grade = 2
                    },
                    new Enrollment
                    {
                        StudentId = students[2].StudentId,
                        Course = courses[0],
                        Grade = 1
                    },
                    new Enrollment
                    {
                        StudentId = students[2].StudentId,
                        Course = courses[1],
                        Grade = 2
                    },
                    new Enrollment
                    {
                        StudentId = students[3].StudentId,
                        Course = courses[0],
                        Grade = 2
                    },
                    new Enrollment
                    {
                        StudentId = students[4].StudentId,
                        Course = courses[5],
                        Grade = 2
                    },
                    new Enrollment
                    {
                        StudentId = students[5].StudentId,
                        Course = courses[6],
                        Grade = 2
                    }
                };

                context.AddRange(enrollments);
                context.SaveChanges();
            }
        }
    }
}