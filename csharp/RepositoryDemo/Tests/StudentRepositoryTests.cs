using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using RepositoryDemo.Models;
using Xunit;
using RepositoryDemo.Repository;

namespace RepositoryDemo.Tests
{
    public class StudentRepositoryTests : ContextSeedData
    {
        protected override void SeedDb(Context context)
        {
            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "Same", LastName = "Same",
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
        }
        
        [Fact]
        public void GetStudents_ReturnsCorrectEntries()
        {
            var studentRepository = new StudentRepository(Context);

            var students = studentRepository.GetStudents().ToList();

            students.Count.Should().Be(8);
        }

        [Fact]
        public void GetStudentsById_ReturnsCorrectEntry()
        {
            var studentLocal = new Student
            {
                StudentId = 1,
                FirstName = "Same", LastName = "Same",
                EnrollmentDate = DateTime.Parse("2010-09-01")
            };
            
            var studentRepository = new StudentRepository(Context);

            var student = studentRepository.GetStudentById(1);
            
            student.Should().BeEquivalentTo(studentLocal);
        }
        
    }
}