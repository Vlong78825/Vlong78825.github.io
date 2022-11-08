using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;


namespace WebApplication1.Repository
{
    
    public class UserRepository : IUserRepository
    {
        private readonly TinhThanhContext _context;
        public UserRepository(TinhThanhContext context)
        {
            _context = context;
        }

        public bool CreateUser(User user)
        {

            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public User GetUser(string username, string password)
        {
            var data =_context.Users.Where(u => u.username == username && u.password == password).FirstOrDefault();
            return data;
        }

        public bool UserExit(string username)
        {
          var data = _context.Users.Where(u => u.username == username ).FirstOrDefault()!=null;

            return data;
        }
    }
}
