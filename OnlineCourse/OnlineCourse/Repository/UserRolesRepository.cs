using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Interface;
using OnlineCourse.Models;

namespace OnlineCourse.Repository
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly AppDbContext _context;
        public UserRolesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Role> AddRoleToUser(int userId, int roleId)
        {
            var userExists = await _context.Users.AnyAsync(u => u.UserId == userId);

            if (!userExists) return null;

            var roleExists = await _context.Roles.AnyAsync(r => r.RoleId == roleId);
            if (!roleExists) return null;

            if (await _context.UserRoles.AnyAsync(ur => ur.UserId == userId && ur.RoleId == roleId))
                throw new Exception("Người dùng đã có vai trò này.");
            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId,
                AssignedAt = DateTime.UtcNow
            };

            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();

            var role = await _context.Roles.FindAsync(roleId);

            return role;
        }

        public async Task<ICollection<Role>> GetRolesForUser(int userId)
        {
            var userExists = await _context.Users.AnyAsync(u => u.UserId == userId);
            if (!userExists) return null;

            var roles = await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Join(_context.Roles,
                      ur => ur.RoleId,
                      r => r.RoleId,
                      (ur, r) => r)
                .ToListAsync();

            return roles;
        }

        public async Task RemoveRoleFromUser(int userId, int roleId)
        {
            var userRole = await _context.UserRoles
            .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (userRole == null) throw new Exception("UserRole not found.");

            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
        }
    }
}
