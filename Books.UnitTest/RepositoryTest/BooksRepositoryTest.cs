using Books.ApplicationCore.Entities;
using Books.ApplicationCore.Entities.BookAggregate;
using Books.Infrastructure;
using Books.Infrastructure.Data;
using Books.UnitTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Books.UnitTest.RepositoryTest
{
    public class BooksRepositoryTest
    {
        private BooksRepository<Category> repository;
        public static DbContextOptions<BooksContext> dbContextOptions { get; }
        public static string connectionString = "Server=DESKTOP-UU6UAJD;Database=BookStandTestDB;Trusted_Connection=True";
        static BooksRepositoryTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<BooksContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public BooksRepositoryTest()
        {
            var context = new BooksContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            repository = new BooksRepository<Category>(context);
        }

        #region Get By Id
       // public async void Task_GetCategoryById_Return_OkResult()
        #endregion
    }
}
