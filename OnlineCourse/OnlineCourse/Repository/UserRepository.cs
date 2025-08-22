using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Interface;
using OnlineCourse.Models;

namespace OnlineCourse.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            user.Role = null; // Ensure Role is not set to null
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public ICollection<User> GetAllUsers()
        {
            return _context.Users
                .Include(u => u.Role) // Include Role navigation property
                .ToList();
        }
    }
}
