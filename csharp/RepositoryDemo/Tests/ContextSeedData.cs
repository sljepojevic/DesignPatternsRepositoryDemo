using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RepositoryDemo.Models;

namespace RepositoryDemo.Tests
{
    public abstract class ContextSeedData : IDisposable
    {
        protected Context Context { get; private set; }
        
        public ContextSeedData()
        {
            Context = new Context(
                new DbContextOptionsBuilder<Context>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);;
            SeedDb(Context);
            Context.SaveChanges();
        }

        private void SeedDb(Context context)
        {
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
        }
        
        public void Dispose()
        {
            var students = Context.Students;
            Context.Students.RemoveRange(students);
        }
    }
}