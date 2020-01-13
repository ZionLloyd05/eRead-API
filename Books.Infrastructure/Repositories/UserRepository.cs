using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.ApplicationCore.Entities;
using Books.ApplicationCore.Entities.UserAggregate;
using Books.ApplicationCore.Interfaces;
using Books.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Repositories
{
    public class UserRepository : BooksRepository<User>, IUserRepository
    {
        private readonly BooksContext _dbContext;

        public UserRepository(BooksContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
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

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
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