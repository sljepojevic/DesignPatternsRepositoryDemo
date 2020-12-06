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

        protected abstract void SeedDb(Context context);
        
        public void Dispose()
        {
            var students = Context.Students;
            Context.Students.RemoveRange(students);
        }
    }
}