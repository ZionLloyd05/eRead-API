using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.ApplicationCore.Entities;
using Books.ApplicationCore.Entities.LibraryAggregate;
using Books.ApplicationCore.Entities.UserAggregate;
using Books.ApplicationCore.Interfaces;
using Books.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Books.Infrastructure.Repositories
{
    public class UserRepository : BooksRepository<User>, IUserRepository
    {
        private readonly BooksContext _dbContext;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(BooksContext dbContext, ILoggerFactory loggerFactory) : base(dbContext)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger<UserRepository>();
        }
        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return null;

            return user;
        }

        public async Task<User> AddUser(User user)
        {

            if (user == null)
                return null;

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation($"User Id => {user.Id}");


            return user;

            //using (var transaction = _dbContext.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        _dbContext.Users.Add(user);
            //        await _dbContext.SaveChangesAsync();

            //        _logger.LogInformation($"User Id => {user.Id}");

            //        _dbContext.Libraries.Add(new Library { UserId = user.Id });
            //        await _dbContext.SaveChangesAsync();

            //        transaction.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //    _logger.LogError($"Error : {ex.InnerException.ToString()}");
            //    }
            //}                        
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _dbContext.Users.Include(p => p.Photo).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _dbContext.Users.Include(p => p.Photo).ToListAsync();

            return users;
        }

        #region Helper Methods


        #endregion
    }
}