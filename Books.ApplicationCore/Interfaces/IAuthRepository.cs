using System.Threading.Tasks;
using Books.ApplicationCore.Entities;
using Books.ApplicationCore.Entities.UserAggregate;

namespace Books.ApplicationCore.Interfaces
{
    public interface IAuthRepository
    {
        Task<bool> UserExists(string email);
        Task<User> Register(User user, string password);
        Task<User> Login(string email, string password);
    }
}