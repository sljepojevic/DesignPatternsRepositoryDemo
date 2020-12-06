using System.Linq;
using FluentAssertions;
using Xunit;
using RepositoryDemo.Repository;

namespace RepositoryDemo.Tests
{
    public class StudentRepositoryTests : ContextSeedData
    {
        [Fact]
        public void GetStudents_ReturnsCorrectEntries()
        {
            var studentRepository = new StudentRepository(Context);

            var students = studentRepository.GetStudents().ToList();

            students.Count.Should().Be(8);
        }
    }
}