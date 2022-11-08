using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string username,string password);
        bool CreateUser(User user);
        bool UserExit(string username);
    }
}
