using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Books.ApplicationCore.Entities;
using Books.ApplicationCore.Entities.UserAggregate;

namespace Books.ApplicationCore.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<User> AddUser(User user);
        Task<User> GetUser(int Id);
        Task<IEnumerable<User>> GetUsers();
    }
}