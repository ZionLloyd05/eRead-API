using System.Linq;
using Books.ApplicationCore.Entities.BookAggregate;

namespace Books.Infrastructure.Data
{
    public static class InitialData
    {
        public static void Seed(this BooksContext dbContext)
        {
            if (!dbContext.Tags.Any())
            {
                dbContext.Tags.AddRange(
                    new Tag { Name = "Faith", Description = "Christian book on faith" },
                    new Tag { Name = "C#", Description = "Programming book on C#" },
                    new Tag { Name = "Spiritual Warfare", Description = "Christian book on warfare" }
                );

                dbContext.SaveChanges();
            }

        }
    }
}