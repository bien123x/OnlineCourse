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

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
            return await _context.Users
                .Include(u => u.Role) // Include Role navigation property
                .ToListAsync();
        }

        public async Task<User?> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task<User?> UpdateUser(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.UserId);
            if (existingUser == null)
                return null;
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.FullName = user.FullName;
            existingUser.DateOfBirth = user.DateOfBirth;
            existingUser.RoleId = user.RoleId;
            existingUser.IsActive = user.IsActive;
            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();

            return existingUser;
        }
    }
}
