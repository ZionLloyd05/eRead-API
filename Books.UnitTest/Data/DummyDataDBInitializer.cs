using Books.ApplicationCore.Entities;
using Books.ApplicationCore.Entities.BookAggregate;
using Books.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.UnitTest.Data
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {

        }

        public void Seed(BooksContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Categories.AddRange(
                new Category() { Name = "Christian", Description = "Books on christian the faith" },
                new Category() { Name = "Programming", Description = "Books for programmers" }
            );

            context.Tags.AddRange(
                new Tag() { Name = "Faith", Description = "Christian book on faith" },
                new Tag() { Name = "C#", Description = "Programming book on C#" },
                new Tag() { Name = "Spiritual Warfare", Description = "Christian book on warfare" }
            );

            context.SaveChanges();
        }
    }
}
