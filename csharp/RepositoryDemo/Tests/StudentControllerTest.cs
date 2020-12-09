using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RepositoryDemo.Controllers;
using RepositoryDemo.Models;
using RepositoryDemo.Repository;
using Xunit;

namespace RepositoryDemo.Tests
{
    public class StudentControllerTest : ContextSeedData
    {
        private readonly MockRepository _mockRepository;

        public StudentControllerTest()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
        }
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
        public void GetStudents_OK()
        {
            var mockStudentRepository = _mockRepository.Create<IStudentRepository>();
            mockStudentRepository.Setup(sr => sr.GetStudentById(1))
                .Returns(new Student{FirstName ="Same", LastName="Same"});
            
            var controller = new StudentController(Context, mockStudentRepository.Object);
            
            controller.CheckIfFirstNameAndLastNameIsTheSame(1).Should().BeEquivalentTo(new OkResult());
        }
        
        [Fact]
        public void GetStudents_Fails()
        {
            var mockStudentRepository = _mockRepository.Create<IStudentRepository>();
            mockStudentRepository.Setup(sr => sr.GetStudentById(1))
                .Returns(new Student{FirstName ="Same", LastName="NotSame"});
            
            var controller = new StudentController(Context, mockStudentRepository.Object);

            Assert.Throws<Exception>(() =>
                controller.CheckIfFirstNameAndLastNameIsTheSame(1));
        }
    }
}