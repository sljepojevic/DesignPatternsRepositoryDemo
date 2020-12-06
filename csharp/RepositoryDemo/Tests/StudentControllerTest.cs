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

        [Fact]
        public void GetStudents_Fails()
        {
           var mockStudentRepository = _mockRepository.Create<IStudentRepository>();
            mockStudentRepository.Setup(sr => sr.GetStudentById(1))
                .Returns(new Student{FirstName ="Same", LastName="Same"});
            
            var controller = new StudentController(Context, mockStudentRepository.Object);
            
            controller.CheckIfFirstNameAndLastNameIsTheSame(1).Should().BeEquivalentTo(new OkResult());
        }
    }
}