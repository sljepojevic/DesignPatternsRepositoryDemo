using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RepositoryDemo.Models;

namespace RepositoryDemo
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    FirstName = "Carson", LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2010-09-01")
                },
                new Student
                {
                    StudentId = 2,
                    FirstName = "Meredith", LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new Student
                {
                    StudentId = 3,
                    FirstName = "Arturo", LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2013-09-01")
                },
                new Student
                {
                    StudentId = 4,
                    FirstName = "Gytis", LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new Student
                {
                    StudentId = 5,
                    FirstName = "Yan", LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2012-09-01")
                },
                new Student
                {
                    StudentId = 6,
                    FirstName = "Peggy", LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2011-09-01")
                },
                new Student
                {
                    StudentId = 7,
                    FirstName = "Laura", LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2013-09-01")
                },
                new Student
                {
                    StudentId = 8,
                    FirstName = "Nino", LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2005-08-11")
                }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course {CourseId = 1, Title = "Chemistry", Credits = 3,},
                new Course {CourseId = 2, Title = "Microeconomics", Credits = 3,},
                new Course {CourseId = 3, Title = "Macroeconomics", Credits = 3,},
                new Course {CourseId = 4, Title = "Calculus", Credits = 4,},
                new Course {CourseId = 5, Title = "Trigonometry", Credits = 4,},
                new Course {CourseId = 6, Title = "Composition", Credits = 3,},
                new Course {CourseId = 7, Title = "Literature", Credits = 4,}
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment
                    {EnrollmentId = 1, StudentId = 1, CourseId = 1, Grade = 1},
                new Enrollment
                    {EnrollmentId = 2, StudentId = 1, CourseId = 2, Grade = 3},
                new Enrollment
                {
                    EnrollmentId = 3,
                    StudentId = 1,
                    CourseId = 3,
                    Grade = 2
                },
                new Enrollment
                {
                    EnrollmentId = 4, 
                    StudentId = 2,
                    CourseId = 4,
                    Grade = 2
                },
                new Enrollment
                {
                    EnrollmentId = 5,
                    StudentId = 2,
                    CourseId = 5,
                    Grade = 2
                },
                new Enrollment
                {
                    EnrollmentId = 6,
                    StudentId = 2,
                    CourseId = 6,
                    Grade = 2
                },
                new Enrollment
                {
                    EnrollmentId = 7,
                    StudentId = 3,
                    CourseId = 1,
                    Grade = 1
                },
                new Enrollment
                {
                    EnrollmentId = 8,
                    StudentId = 3,
                    CourseId = 2,
                    Grade = 2
                },
                new Enrollment
                {
                    EnrollmentId = 9,
                    StudentId = 4,
                    CourseId = 1,
                    Grade = 2
                },
                new Enrollment
                {
                    EnrollmentId = 10,
                    StudentId = 5,
                    CourseId = 6,
                    Grade = 2
                },
                new Enrollment
                {
                    EnrollmentId = 11,
                    StudentId = 6,
                    CourseId = 7,
                    Grade = 2
                });
        }
    }
}